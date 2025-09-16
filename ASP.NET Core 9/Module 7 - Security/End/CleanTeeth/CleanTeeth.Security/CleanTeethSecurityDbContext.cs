using CleanTeeth.Security.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Security
{
    public class CleanTeethSecurityDbContext : IdentityDbContext<User>
    {
        public CleanTeethSecurityDbContext(DbContextOptions<CleanTeethSecurityDbContext> options) : base(options)
        {
        }

        protected CleanTeethSecurityDbContext()
        {
        }
    }
}
