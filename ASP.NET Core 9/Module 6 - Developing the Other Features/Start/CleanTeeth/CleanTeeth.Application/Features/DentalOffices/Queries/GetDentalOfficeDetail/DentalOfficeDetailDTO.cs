using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Application.Features.DentalOffices.Queries.GetDentalOfficeDetail
{
    public class DentalOfficeDetailDTO
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
    }
}
