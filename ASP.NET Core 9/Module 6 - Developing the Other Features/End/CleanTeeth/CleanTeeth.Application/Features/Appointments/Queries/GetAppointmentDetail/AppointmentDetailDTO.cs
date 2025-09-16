using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Application.Features.Appointments.Queries.GetAppointmentDetail
{
    public class AppointmentDetailDTO
    {
        public required Guid Id { get; set; }
        public required string Patient { get; set; }
        public required string Dentist { get; set; }
        public required string DentalOffice { get; set; }
        public required DateTime StartDate { get; set; }
        public required DateTime EndDate { get; set; }
        public required string Status { get; set; }

    }
}
