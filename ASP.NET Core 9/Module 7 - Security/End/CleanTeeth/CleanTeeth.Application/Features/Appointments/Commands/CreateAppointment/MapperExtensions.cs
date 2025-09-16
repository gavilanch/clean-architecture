using CleanTeeth.Application.Notifications;
using CleanTeeth.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Application.Features.Appointments.Commands.CreateAppointment
{
    internal static class MapperExtensions
    {
        internal static AppointmentConfirmationDTO ToDto(this Appointment appointment)
        {
            return new AppointmentConfirmationDTO
            {
                Id = appointment.Id,
                Date = appointment.TimeInterval.Start,
                Patient = appointment.Patient!.Name,
                Patient_Email = appointment.Patient!.Email.Value,
                DentalOffice = appointment.DentalOffice!.Name,
                Dentist = appointment.Dentist!.Name
            };
        }
    }
}
