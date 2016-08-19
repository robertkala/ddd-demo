using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDDemo.Common.Exceptions
{
    public class DomainInvariantException : Exception
    {
        public DomainInvariantException(string message) : base(message)
        {
        }
    }
}
