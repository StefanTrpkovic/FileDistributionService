using Domain.Repositories;

namespace Persistence.Repositories
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<IChannelRepository> _lazyChannelRepository;
        private readonly Lazy<IClientRepository> _lazyClientRepository;
        private readonly Lazy<IUpdateRepository> _lazyUpdateRepository;
        private readonly Lazy<IVersionRepository> _lazyVersionRepository;
        private readonly Lazy<ISoftwareRepository> _lazySoftwareRepository;

        public RepositoryManager(RepositoryDbContext dbContext)
        {
            _lazyChannelRepository = new Lazy<IChannelRepository>(() => new ChannelRepository(dbContext));
            _lazyClientRepository = new Lazy<IClientRepository>(() => new ClientRepository(dbContext));
            _lazyUpdateRepository = new Lazy<IUpdateRepository>(() => new UpdateRepository(dbContext));
            _lazyVersionRepository = new Lazy<IVersionRepository>(() => new VersionRepository(dbContext));
            _lazySoftwareRepository = new Lazy<ISoftwareRepository>(() => new SoftwareRepository(dbContext));
        }

        public IChannelRepository ChannelRepository => _lazyChannelRepository.Value;
        public IClientRepository ClientRepository => _lazyClientRepository.Value;
        public IUpdateRepository UpdateRepository => _lazyUpdateRepository.Value;
        public IVersionRepository VersionRepository => _lazyVersionRepository.Value;
        public ISoftwareRepository SoftwareRepository => _lazySoftwareRepository.Value;
    }
}
