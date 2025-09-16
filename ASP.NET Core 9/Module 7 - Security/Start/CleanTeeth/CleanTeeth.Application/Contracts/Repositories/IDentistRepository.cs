using CleanTeeth.Application.Features.Patients.Queries.GetPatientsList;
using CleanTeeth.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Application.Contracts.Repositories
{
    public interface IPatientRepository: IRepository<Patient>
    {
        Task<IEnumerable<Patient>> GetFiltered(PatientsFilterDTO filter);
    }
}
