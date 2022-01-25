using Domain.Entities;
using Domain.Repositories;

namespace Persistence.Repositories
{
    internal class SoftwareRepository : ISoftwareRepository
    {
        private readonly RepositoryDbContext _dbContext;

        public SoftwareRepository(RepositoryDbContext dbContext) => _dbContext = dbContext;

        public bool ValidateSoftCounAvailability(int softwareId, int countryId) =>
           _dbContext.SoftwareCountry.Any(x => x.SoftwareId == softwareId && x.CountryId == countryId);

        public Software CheckSoftwarePackage(string packageId) =>
            _dbContext.Software.FirstOrDefault(x => x.PackageId.Equals(packageId));

        public Software GetSoftwareByNameAndVersion(string name, int version) =>
            _dbContext.Software.FirstOrDefault(x => x.Name.Equals(name) && x.Version == version);
    }
}
