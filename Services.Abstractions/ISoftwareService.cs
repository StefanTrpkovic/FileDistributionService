namespace Services.Abstractions
{
    public interface ISoftwareService
    {
        void ValidateSoftCounAvailability(int softwareId, int countryId);
        void ValidateDateAvailability(int softwareId, int version);
    }
}
