using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using Services.Abstractions;

namespace Services
{
    internal class SoftwareService : ISoftwareService
    {
        private readonly IRepositoryManager _repositoryManager;

        public SoftwareService(IRepositoryManager repositoryManager) => _repositoryManager = repositoryManager;


        public void ValidateSoftCounAvailability(int softwareId, int countryId)
        {
            var result = _repositoryManager.SoftwareRepository.ValidateSoftCounAvailability(softwareId, countryId);

            if (!result)
                throw new SoftwareCountryException();
        }
        public void ValidateDateAvailability(DateTime releaseDate)
        {
            if (releaseDate > DateTime.Now)
                throw new SoftwareUpdateException();
        }

        public Software ValidateVersion(Software software, int version)
        {
            var foundSoftware = _repositoryManager.SoftwareRepository.GetSoftwareByNameAndVersion(software.Name, version);

            if(foundSoftware == null)
                throw new NotExistantVersionException();

            if (version == software.Version)
                throw new SameVersionException();

            if (version < software.Version)
                throw new NewerVersionException();

            if ((version - software.Version) > 1)
                throw new SkipVersionException();

            return foundSoftware;
        }

        public Software CheckSoftwarePackage(string packageId)
        {
            var packageIdDb = _repositoryManager.SoftwareRepository.CheckSoftwarePackage(packageId);

            if (packageIdDb == null)
                throw new InvalidPackageException();

            return packageIdDb;
        }

        public void UpdateClientSoftware(int softwareId, int desiredSoftwareId, int clientId)
        {
            _repositoryManager.UpdateRepository.UpdateClientSoftware(softwareId, desiredSoftwareId, clientId);
        }
    }
}
