using CleanTeeth.Application.Contracts.Repositories.Models;
using CleanTeeth.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Application.Features.Appointments.Queries.GetAppointmentsList
{
    public class GetAppointmentsListQuery: AppointmentsFilterDTO, IRequest<List<AppointmentsListDTO>>
    {
    }
}
