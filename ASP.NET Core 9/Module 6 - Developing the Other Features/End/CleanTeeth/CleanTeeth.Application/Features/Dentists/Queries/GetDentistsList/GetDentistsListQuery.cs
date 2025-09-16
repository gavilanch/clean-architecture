using CleanTeeth.Application.Utilities;
using CleanTeeth.Application.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Application.Features.Dentists.Queries.GetDentistsList
{
    public class GetDentistsListQuery: DentistsFilterDTO, IRequest<PaginatedDTO<DentistListDTO>>
    {
    }
}
