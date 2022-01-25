using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class ChannelSoftwareException : Exception 
    {
        public ChannelSoftwareException() : base("This software is not in, or has higher priority than the channel you subscribed") { }
    }
}
