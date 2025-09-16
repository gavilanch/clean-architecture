using CleanTeeth.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Domain.Entities
{
    public class DentalOffice
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = null!;

        public DentalOffice(string name)
        {
            EnforceNameBusinessRules(name);

            Name = name;
            Id = Guid.CreateVersion7();
        }

        public void UpdateName(string name)
        {
            EnforceNameBusinessRules(name);
            Name = name;
        }


        private void EnforceNameBusinessRules(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new BusinessRuleException($"The {nameof(name)} is required");
            }
        }
    }
}
