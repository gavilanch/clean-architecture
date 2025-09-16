using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Utilities;
using CleanTeeth.Application.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Application.Features.Patients.Queries.GetPatientsList
{
    public class GetPatientsListQueryHandler : IRequestHandler<GetPatientsListQuery, PaginatedDTO<PatientListDTO>>
    {
        private readonly IPatientRepository repository;

        public GetPatientsListQueryHandler(IPatientRepository repository)
        {
            this.repository = repository;
        }

        public async Task<PaginatedDTO<PatientListDTO>> Handle(GetPatientsListQuery request)
        {
            var patients = await repository.GetFiltered(request);
            var totalAmountOfRecords = await repository.GetTotalAmountOfRecords();
            var patientsDTO = patients.Select(patient => patient.ToDto()).ToList();

            var paginatedDTO = new PaginatedDTO<PatientListDTO>
            {
                Elements = patientsDTO,
                TotalAmountOfRecords = totalAmountOfRecords
            };


            return paginatedDTO;
        }
    }
}
