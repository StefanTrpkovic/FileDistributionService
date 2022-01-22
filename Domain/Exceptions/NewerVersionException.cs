using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public sealed class NewerVersionException : Exception
    {
        public NewerVersionException() : base("You have a newer version installed of the package") { }
    }
}