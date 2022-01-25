using Domain.Entities;

namespace Domain.Repositories
{
    public interface IUpdateRepository
    {
        void UpdateClientSoftware(int softwareId, int desiredSoftwareId, int clientId);
    }
}
