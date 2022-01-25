using Domain.Repositories;

namespace Persistence.Repositories
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<IClientRepository> _lazyClientRepository;
        private readonly Lazy<ISoftwareRepository> _lazySoftwareRepository;
        private readonly Lazy<IUpdateRepository> _lazyUpdateRepository;

        public RepositoryManager(RepositoryDbContext dbContext)
        {
            _lazyClientRepository = new Lazy<IClientRepository>(() => new ClientRepository(dbContext));
            _lazySoftwareRepository = new Lazy<ISoftwareRepository>(() => new SoftwareRepository(dbContext));
            _lazyUpdateRepository = new Lazy<IUpdateRepository>(() => new UpdateRepository(dbContext));
        }

        public IClientRepository ClientRepository => _lazyClientRepository.Value;
        public ISoftwareRepository SoftwareRepository => _lazySoftwareRepository.Value;
        public IUpdateRepository UpdateRepository => _lazyUpdateRepository.Value;
    }
}
