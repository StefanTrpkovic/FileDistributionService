using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public sealed class NotExistantVersionException : Exception
    {
        public NotExistantVersionException() : base("The version you are looking for doesn't exist") { }
    }
}