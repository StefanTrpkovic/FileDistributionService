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
        public void ValidateDateAvailability(int softwareId, int version)
        {
            var softChannel = _repositoryManager.SoftwareRepository.ValidateDateAvailability(softwareId, version);

            if (softChannel != null)
            {
                if (softChannel.ReleaseDate > DateTime.Now)
                    throw new SoftwareUpdateException();
            }
        }
    }
}
