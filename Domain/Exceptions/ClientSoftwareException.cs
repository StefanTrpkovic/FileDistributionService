using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public sealed class ClientSoftwareException : Exception
    {
        public ClientSoftwareException() : base("The specified client hasn't installed the requested software package previosuly") { }
    }
}
