using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public sealed class SkipVersionException : Exception
    {
        public SkipVersionException() : base("You can not skip versions. You must ask for the next version from the one you already have") { }
    }
}