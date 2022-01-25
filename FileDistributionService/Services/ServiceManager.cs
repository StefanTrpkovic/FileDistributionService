using Domain.Repositories;
using Services.Abstractions;

namespace Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IClientService> _lazyClientService;
        private readonly Lazy<ISoftwareService> _lazySoftwareService;

        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _lazyClientService = new Lazy<IClientService>(() => new ClientService(repositoryManager));
            _lazySoftwareService = new Lazy<ISoftwareService>(() => new SoftwareService(repositoryManager));
        }

        public IClientService ClientService => _lazyClientService.Value;

        public ISoftwareService SoftwareService => _lazySoftwareService.Value;
    }
}
