using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class SoftwareCountryException : Exception 
    {
        public SoftwareCountryException() : base("The software is not available for your country")
        {

        }
    }
}
