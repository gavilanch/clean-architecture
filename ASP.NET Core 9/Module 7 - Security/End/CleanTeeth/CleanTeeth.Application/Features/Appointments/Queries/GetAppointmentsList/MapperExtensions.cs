using CleanTeeth.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Application.Features.Appointments.Queries.GetAppointmentsList
{
    internal static class MapperExtensions
    {
        internal static AppointmentsListDTO ToDto(this Appointment appointment)
        {
            return new AppointmentsListDTO
            {
                Id = appointment.Id,
                StartDate = appointment.TimeInterval.Start,
                EndDate = appointment.TimeInterval.End,
                DentalOffice = appointment.DentalOffice!.Name,
                Dentist = appointment.Dentist!.Name,
                Patient = appointment.Patient!.Name,
                Status = appointment.Status.ToString()
            };
        }
    }
}
