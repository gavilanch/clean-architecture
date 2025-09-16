using CleanTeeth.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Persistence.Configurations
{
    internal class PatientConfig : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.Property(prop => prop.Name)
                .HasMaxLength(250)
                .IsRequired();

            builder.ComplexProperty(prop => prop.Email, action =>
            {
                action.Property(e => e.Value).HasColumnName("Email").HasMaxLength(254);
            });

        }
    }
}
