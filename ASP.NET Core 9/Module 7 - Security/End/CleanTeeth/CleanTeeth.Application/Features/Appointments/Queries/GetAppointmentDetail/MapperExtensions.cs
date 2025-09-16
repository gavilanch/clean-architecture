using CleanTeeth.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Application.Features.Appointments.Queries.GetAppointmentDetail
{
    internal static class MapperExtensions
    {
        internal static AppointmentDetailDTO ToDto(this Appointment appointment)
        {
            return new AppointmentDetailDTO
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
