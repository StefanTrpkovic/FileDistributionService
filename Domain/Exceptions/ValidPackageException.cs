using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class ValidPackageException : Exception 
    {
        public ValidPackageException() : base("Please insert a valid package id") { }
    }
}
