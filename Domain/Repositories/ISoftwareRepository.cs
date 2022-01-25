using Domain.Entities;

namespace Domain.Repositories
{
    public interface ISoftwareRepository
    {
        bool ValidateSoftCounAvailability(int softwareId, int countryId);
        Software CheckSoftwarePackage(string packageId);
        Software GetSoftwareByNameAndVersion(string name, int version);
    }
}
