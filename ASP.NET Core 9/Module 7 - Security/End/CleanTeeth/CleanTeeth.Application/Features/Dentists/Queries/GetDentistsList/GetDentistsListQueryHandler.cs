using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Utilities;
using CleanTeeth.Application.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Application.Features.Dentists.Queries.GetDentistsList
{
    public class GetDentistsListQueryHandler : IRequestHandler<GetDentistsListQuery, PaginatedDTO<DentistListDTO>>
    {
        private readonly IDentistRepository repository;

        public GetDentistsListQueryHandler(IDentistRepository repository)
        {
            this.repository = repository;
        }

        public async Task<PaginatedDTO<DentistListDTO>> Handle(GetDentistsListQuery request)
        {
            var Dentists = await repository.GetFiltered(request);
            var totalAmountOfRecords = await repository.GetTotalAmountOfRecords();
            var DentistsDTO = Dentists.Select(Dentist => Dentist.ToDto()).ToList();

            var paginatedDTO = new PaginatedDTO<DentistListDTO>
            {
                Elements = DentistsDTO,
                TotalAmountOfRecords = totalAmountOfRecords
            };


            return paginatedDTO;
        }
    }
}
