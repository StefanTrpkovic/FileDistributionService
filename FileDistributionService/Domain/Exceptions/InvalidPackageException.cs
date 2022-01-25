using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class InvalidPackageException : Exception 
    {
        public InvalidPackageException() : base("Please insert a valid package id") { }
    }
}
