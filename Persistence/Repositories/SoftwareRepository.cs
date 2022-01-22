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
        public Software ValidateDateAvailability(int softwareId, int version) =>
            _dbContext.Software.FirstOrDefault(y => y.Id == softwareId && y.Version == version);
        public Software ValidateVersion(ClientSoftware clientSoftware) =>
            _dbContext.Software.FirstOrDefault(y => y.Id == clientSoftware.SoftwareId);
    }
}
