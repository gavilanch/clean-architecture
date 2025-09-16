using CleanTeeth.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Application.Features.DentalOffices.Queries.GetDentalOfficeDetail
{
    internal static class MapperExtensions
    {
        public static DentalOfficeDetailDTO ToDTO(this DentalOffice dentalOffice)
        {
            var dto = new DentalOfficeDetailDTO
            {
                Id = dentalOffice.Id,
                Name = dentalOffice.Name
            };

            return dto;
        }
    }
}
