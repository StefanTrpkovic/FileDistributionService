using Domain.Entities;
using Domain.Repositories;

namespace Persistence.Repositories
{
    internal class UpdateRepository : IUpdateRepository
    {
        private readonly RepositoryDbContext _dbContext;

        public UpdateRepository(RepositoryDbContext dbContext) => _dbContext = dbContext;

        public Software CheckSoftwarePackage(string packageId) =>
            _dbContext.Software.FirstOrDefault(x => x.PackageVersion.ToString().Equals(packageId));
    }
}
