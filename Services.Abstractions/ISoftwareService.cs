using Domain.Entities;

namespace Services.Abstractions
{
    public interface ISoftwareService
    {
        void ValidateSoftCounAvailability(int softwareId, int countryId);
        void ValidateDateAvailability(DateTime releaseDate);
        Software ValidateVersion(Software softwareVersion, int version);
        Software CheckSoftwarePackage(string packageId);
        void UpdateClientSoftware(int softwareId, int desiredSoftwareId, int clientId);
    }
}
