using CleanTeeth.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Domain.ValueObjects
{
    public record Email
    {
        public string Value { get; } = null!;

        private Email() { }

        public Email(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new BusinessRuleException($"The {nameof(email)} is required");
            }

            if (!email.Contains("@"))
            {
                throw new BusinessRuleException($"The {nameof(email)} is not valid");
            }

            Value = email;

        }
    }
}
