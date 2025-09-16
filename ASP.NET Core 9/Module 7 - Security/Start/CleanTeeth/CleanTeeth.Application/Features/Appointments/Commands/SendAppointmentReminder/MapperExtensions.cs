using CleanTeeth.Application.Notifications;
using CleanTeeth.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Application.Features.Appointments.Commands.SendAppointmentReminder
{
    internal static class MapperExtensions
    {
        internal static AppointmentReminderDTO toDto(this Appointment appointment)
        {
            return new AppointmentReminderDTO
            {
                Id = appointment.Id,
                Date = appointment.TimeInterval.Start,
                Patient = appointment.Patient!.Name,
                Patient_Email = appointment.Patient!.Email.Value,
                Dentist = appointment.Dentist!.Name,
                DentalOffice = appointment.DentalOffice!.Name
            };
        }
    }
}
