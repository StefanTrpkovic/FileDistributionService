using Domain.Repositories;
using Services.Abstractions;

namespace Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IChannelService> _lazyChannelService;
        private readonly Lazy<IClientService> _lazyClientService;
        private readonly Lazy<IUpdateService> _lazyUpdateService;
        private readonly Lazy<IVersionService> _lazyVersionService;
        private readonly Lazy<ISoftwareService> _lazySoftwareService;

        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _lazyChannelService = new Lazy<IChannelService>(() => new ChannelService(repositoryManager));
            _lazyClientService = new Lazy<IClientService>(() => new ClientService(repositoryManager));
            _lazyUpdateService = new Lazy<IUpdateService>(() => new UpdateService(repositoryManager));
            _lazyVersionService = new Lazy<IVersionService>(() => new VersionService(repositoryManager));
            _lazySoftwareService = new Lazy<ISoftwareService>(() => new SoftwareService(repositoryManager));
        }

        public IChannelService ChannelService => _lazyChannelService.Value;

        public IClientService ClientService => _lazyClientService.Value;

        public IUpdateService UpdateService => _lazyUpdateService.Value;

        public IVersionService VersionService => _lazyVersionService.Value;

        public ISoftwareService SoftwareService => _lazySoftwareService.Value;
    }
}
