using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public sealed class SameVersionException : Exception
    {
        public SameVersionException()
            : base("You already have that version installed of the package")
        {
        }
    }
}