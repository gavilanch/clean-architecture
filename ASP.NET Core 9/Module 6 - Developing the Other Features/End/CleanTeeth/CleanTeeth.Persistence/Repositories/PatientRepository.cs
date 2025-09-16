using CleanTeeth.Application.Contracts.Repositories;
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
    public class PatientRepository: Repository<Patient>, IPatientRepository
    {
        private readonly CleanTeethDbContext context;

        public PatientRepository(CleanTeethDbContext context)
            :base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Patient>> GetFiltered(PatientsFilterDTO filter)
        {
            var queryable = context.Patients.AsQueryable();

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
