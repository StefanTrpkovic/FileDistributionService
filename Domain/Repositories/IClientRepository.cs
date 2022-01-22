using Domain.Entities;

namespace Domain.Repositories
{
    public interface IClientRepository
    {
        Client GeClientFromUserEmail(object userEmail);
        ClientSoftware GetClientSoftware(int clientId, int softwareId);
    }
}
