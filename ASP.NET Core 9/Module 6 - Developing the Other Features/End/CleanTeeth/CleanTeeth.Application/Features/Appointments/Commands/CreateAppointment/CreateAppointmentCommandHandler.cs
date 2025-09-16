using CleanTeeth.Application.Contracts.Persistence;
using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Exceptions;
using CleanTeeth.Application.Notifications;
using CleanTeeth.Application.Utilities;
using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Application.Features.Appointments.Commands.CreateAppointment
{
    public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommand, Guid>
    {
        private readonly IAppointmentRepository repository;
        private readonly IUnitOfWork unitOfWork;
        private readonly INotifications notifications;

        public CreateAppointmentCommandHandler(IAppointmentRepository repository,
            IUnitOfWork unitOfWork, INotifications notifications)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
            this.notifications = notifications;
        }

        public async Task<Guid> Handle(CreateAppointmentCommand request)
        {
            var existsOverlap = await repository.OverlapExists(request.DentistId, request.StartDate,
                request.EndDate);

            if (existsOverlap)
            {
                throw new CustomValidationException("The dentist have an appointment that overlaps");
            }

            var timeInterval = new TimeInterval(request.StartDate, request.EndDate);
            var appointment = new Appointment(request.PatientId, request.DentistId, request.DentalOfficeId,
                timeInterval);

            Guid? id = null;

            try
            {
                var result = await repository.Add(appointment);
                await unitOfWork.Commit();
                id = result.Id;
            }
            catch (Exception)
            {
                await unitOfWork.Rollback();
                throw;
            }

            var appointmentDB = await repository.GetById(id.Value);
            var notificationDTO = appointmentDB!.ToDto();
            await notifications.SendAppointmentConfirmation(notificationDTO);
            return id.Value;
        }
    }
}
