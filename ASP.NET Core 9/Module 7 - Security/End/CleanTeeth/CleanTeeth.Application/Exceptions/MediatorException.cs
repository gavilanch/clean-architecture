using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Application.Exceptions
{
    public class MediatorException: Exception
    {
        public MediatorException(string message)
            :base(message)
        {
            
        }
    }
}
