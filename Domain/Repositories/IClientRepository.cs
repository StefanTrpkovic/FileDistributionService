using Domain.Entities;

namespace Domain.Repositories
{
    public interface IClientRepository
    {
        Client GeClientFromUserEmail(object userEmail);
        ClientSoftwareVersion GetClientSoftwareVersion(int clientId, int softwareId);
    }
}
