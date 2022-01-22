using Domain.Entities;

namespace Domain.Repositories
{
    public interface ISoftwareRepository
    {
        bool ValidateSoftCounAvailability(int softwareId, int countryId);
        Software ValidateDateAvailability(int softwareId, int version);
        Software ValidateVersion(ClientSoftware clientSoftware);
    }
}
