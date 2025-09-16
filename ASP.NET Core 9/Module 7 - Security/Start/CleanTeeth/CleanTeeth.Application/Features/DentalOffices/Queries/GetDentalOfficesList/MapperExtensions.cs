using CleanTeeth.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Application.Features.DentalOffices.Queries.GetDentalOfficesList
{
    internal static class MapperExtensions
    {
        public static DentalOfficesListDTO ToDTO(this DentalOffice dentalOffice)
        {
            var dto = new DentalOfficesListDTO
            {
                Id = dentalOffice.Id,
                Name = dentalOffice.Name
            };
            return dto;
        }
    }
}
