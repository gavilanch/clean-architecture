using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Exceptions;
using CleanTeeth.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Application.Features.Patients.Queries.GetPatientDetail
{
    public class GetPatientDetailQueryHandler : IRequestHandler<GetPatientDetailQuery, PatientDetailDTO>
    {
        private readonly IPatientRepository repository;

        public GetPatientDetailQueryHandler(IPatientRepository repository)
        {
            this.repository = repository;
        }

        public async Task<PatientDetailDTO> Handle(GetPatientDetailQuery request)
        {
            var patient = await repository.GetById(request.Id);

            if (patient is null)
            {
                throw new NotFoundException();
            }

            return patient.ToDto();
        }
    }
}
