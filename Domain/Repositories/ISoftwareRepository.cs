using Domain.Entities;

namespace Domain.Repositories
{
    public interface ISoftwareRepository
    {
        bool ValidateSoftCounAvailability(int softwareId, int countryId);

        SoftwareVersion ValidateDateAvailability(int softwareId, int version);
    }
}
