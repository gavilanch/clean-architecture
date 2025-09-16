using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Persistence.Repositories
{
    public class DentalOfficeRepository: Repository<DentalOffice>, IDentalOfficeRepository
    {
        public DentalOfficeRepository(CleanTeethDbContext context)
            :base(context)
        {
            
        }
    }
}
