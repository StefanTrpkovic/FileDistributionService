using Domain.Entities;
using Domain.Repositories;
using Version = Domain.Entities.Version;

namespace Persistence.Repositories
{
    internal class VersionRepository : IVersionRepository
    {
        private readonly RepositoryDbContext _dbContext;

        public VersionRepository(RepositoryDbContext dbContext) => _dbContext = dbContext;

        public Version ValidateVersion(ClientSoftwareVersion clientSoftwareVersion) =>
             _dbContext.Version.FirstOrDefault(y => y.Id == clientSoftwareVersion.VersionId);
    }
}
