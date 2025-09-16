using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Features.Dentists.Queries.GetDentistsList;
using CleanTeeth.Application.Features.Patients.Queries.GetPatientsList;
using CleanTeeth.Domain.Entities;
using CleanTeeth.Persistence.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Persistence.Repositories
{
    public class DentistRepository: Repository<Dentist>, IDentistRepository
    {
        private readonly CleanTeethDbContext context;

        public DentistRepository(CleanTeethDbContext context)
            :base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Dentist>> GetFiltered(DentistsFilterDTO filter)
        {
            var queryable = context.Dentists.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Name))
            {
                queryable = queryable.Where(x => x.Name.Contains(filter.Name));
            }

            if (!string.IsNullOrWhiteSpace(filter.Email))
            {
                queryable = queryable.Where(x => x.Email.Value.Contains(filter.Email));
            }

            return await queryable.OrderBy(x => x.Name).Paginate(filter.Page, filter.RecordsPerPage)
                .ToListAsync();
        }
    }
}
