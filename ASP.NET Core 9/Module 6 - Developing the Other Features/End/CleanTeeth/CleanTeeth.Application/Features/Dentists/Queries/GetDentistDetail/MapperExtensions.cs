using CleanTeeth.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Application.Features.Dentists.Queries.GetDentistDetail
{
    internal static class MapperExtensions
    {
        internal static DentistDetailDTO ToDto(this Dentist Dentist)
        {
            return new DentistDetailDTO
            {
                Id = Dentist.Id,
                Name = Dentist.Name,
                Email = Dentist.Email.Value
            };
        }
    }
}
