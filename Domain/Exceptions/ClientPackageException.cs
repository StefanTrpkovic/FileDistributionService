using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public sealed class ClientPackageException : Exception
    {
        public ClientPackageException()
            : base("The specified client hasn't installed the requested package previosuly")
        {
        }
    }
}
