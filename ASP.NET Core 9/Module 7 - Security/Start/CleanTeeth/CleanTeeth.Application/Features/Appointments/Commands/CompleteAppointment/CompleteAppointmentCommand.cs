using CleanTeeth.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Application.Features.Appointments.Commands.CompleteAppointment
{
    public class CompleteAppointmentCommand: IRequest
    {
        public required Guid Id { get; set; }
    }
}
