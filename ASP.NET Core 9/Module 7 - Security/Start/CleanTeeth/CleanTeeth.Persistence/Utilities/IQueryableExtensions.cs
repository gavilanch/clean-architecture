using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Persistence.Utilities
{
    internal static class IQueryableExtensions
    {
        internal static IQueryable<T> Paginate<T>(this IQueryable<T> queryable, 
            int page, int recordsPerPage)
        {
            return queryable
                .Skip((page - 1) * recordsPerPage)
                .Take(recordsPerPage);
        }
    }
}
