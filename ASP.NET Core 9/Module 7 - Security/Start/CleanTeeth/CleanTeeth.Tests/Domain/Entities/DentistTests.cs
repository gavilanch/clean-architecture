using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.Exceptions;
using CleanTeeth.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Tests.Domain.Entities
{
    [TestClass]
    public class DentistTests
    {
        [TestMethod]
        [ExpectedException(typeof(BusinessRuleException))]
        public void Constructor_NullName_Throws()
        {
            var email = new Email("felipe@example.com");
            new Dentist(null!, email);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessRuleException))]
        public void Constructor_NullEmail_Throws()
        {
            new Dentist("Felipe", email: null!);
        }

        [TestMethod]
        public void Constructor_ValidDentist_NoExceptions()
        {
            var email = new Email("felipe@example.com");
            new Dentist("Felipe", email);
        }

    }
}
