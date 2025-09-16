using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Exceptions;
using CleanTeeth.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Application.Features.Appointments.Queries.GetAppointmentDetail
{
    public class GetAppointmentDetailQueryHandler : IRequestHandler<GetAppointmentDetailQuery, AppointmentDetailDTO>
    {
        private readonly IAppointmentRepository repository;

        public GetAppointmentDetailQueryHandler(IAppointmentRepository repository)
        {
            this.repository = repository;
        }

        public async Task<AppointmentDetailDTO> Handle(GetAppointmentDetailQuery request)
        {
            var appointment = await repository.GetById(request.Id);

            if (appointment is null)
            {
                throw new NotFoundException();
            }

            return appointment.ToDto();
        }
    }
}
