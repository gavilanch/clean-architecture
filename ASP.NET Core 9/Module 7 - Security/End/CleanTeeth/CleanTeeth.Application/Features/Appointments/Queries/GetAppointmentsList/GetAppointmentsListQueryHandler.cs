using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Application.Features.Appointments.Queries.GetAppointmentsList
{
    public class GetAppointmentsListQueryHandler : IRequestHandler<GetAppointmentsListQuery, List<AppointmentsListDTO>>
    {
        private readonly IAppointmentRepository repository;

        public GetAppointmentsListQueryHandler(IAppointmentRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<AppointmentsListDTO>> Handle(GetAppointmentsListQuery request)
        {
            var appointments = await repository.GetFiltered(request);
            var appointmentsDTO = appointments.Select(appointment => appointment.ToDto()).ToList();
            return appointmentsDTO;
        }
    }
}
