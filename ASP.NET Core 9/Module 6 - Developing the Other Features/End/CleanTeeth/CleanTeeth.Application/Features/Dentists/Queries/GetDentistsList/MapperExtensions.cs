using CleanTeeth.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Application.Features.Dentists.Queries.GetDentistsList
{
    internal static class MapperExtensions
    {
        internal static DentistListDTO ToDto(this Dentist Dentist)
        {
            return new DentistListDTO
            {
                Id = Dentist.Id,
                Name = Dentist.Name,
                Email = Dentist.Email.Value
            };
        }
    }
}
