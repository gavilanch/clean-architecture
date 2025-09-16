using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Application.Features.DentalOffices.Queries.GetDentalOfficesList
{
    public class GetDentalOfficesListQueryHandler : 
            IRequestHandler<GetDentalOfficesListQuery, List<DentalOfficesListDTO>>
    {
        private readonly IDentalOfficeRepository repository;

        public GetDentalOfficesListQueryHandler(IDentalOfficeRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<DentalOfficesListDTO>> Handle(GetDentalOfficesListQuery request)
        {
            var dentalOffices = await repository.GetAll();
            var dentalOfficesDTO = dentalOffices.Select(dentalOffice => dentalOffice.ToDTO()).ToList();
            return dentalOfficesDTO;
        }
    }
}
