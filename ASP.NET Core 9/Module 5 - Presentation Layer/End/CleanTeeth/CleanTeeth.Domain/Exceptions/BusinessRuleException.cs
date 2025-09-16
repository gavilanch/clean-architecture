using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Domain.Exceptions
{
    public class BusinessRuleException: Exception
    {
        public BusinessRuleException(string message)
            :base(message)
        {
            
        }
    }
}
