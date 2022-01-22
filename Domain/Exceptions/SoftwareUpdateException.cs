using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class SoftwareUpdateException : Exception 
    {
        public SoftwareUpdateException() : base("This software has still not been released for update") { }
    }
}
