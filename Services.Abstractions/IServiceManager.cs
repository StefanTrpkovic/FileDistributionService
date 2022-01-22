using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IServiceManager
    {
        IChannelService ChannelService { get; }
        IClientService ClientService { get; }
        IUpdateService UpdateService { get; }
        ISoftwareService SoftwareService { get; }
    }
}
