using CleanTeeth.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Application.Contracts.Repositories.Models
{
    public class AppointmentsFilterDTO
    {
        public Guid? PatientId { get; set; }
        public Guid? DentistId { get; set; }
        public Guid? DentalOfficeId { get; set; }
        public AppointmentStatus? AppointmentStatus { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
