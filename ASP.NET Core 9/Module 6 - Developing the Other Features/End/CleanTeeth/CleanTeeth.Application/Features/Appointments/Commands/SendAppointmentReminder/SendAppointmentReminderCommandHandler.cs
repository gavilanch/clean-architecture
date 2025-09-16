using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Contracts.Repositories.Models;
using CleanTeeth.Application.Notifications;
using CleanTeeth.Application.Utilities;
using CleanTeeth.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Application.Features.Appointments.Commands.SendAppointmentReminder
{
    public class SendAppointmentReminderCommandHandler : IRequestHandler<SendAppointmentReminderCommand>
    {
        private readonly IAppointmentRepository repository;
        private readonly INotifications notifications;

        public SendAppointmentReminderCommandHandler(IAppointmentRepository repository,
            INotifications notifications)
        {
            this.repository = repository;
            this.notifications = notifications;
        }

        public async Task Handle(SendAppointmentReminderCommand request)
        {
            var startDate = DateTime.UtcNow.Date.AddDays(1);
            var endDate = startDate.AddDays(1);
            var filter = new AppointmentsFilterDTO
            {
                StartDate = startDate,
                EndDate = endDate,
                AppointmentStatus = AppointmentStatus.Scheduled
            };

            var appointments = await repository.GetFiltered(filter);

            foreach (var appointment in appointments)
            {
                var dto = appointment.toDto();
                await notifications.SendAppointmentReminder(dto);
            }

        }
    }
}
