using Domain.Entities;

namespace Domain.Repositories
{
    public interface IClientRepository
    {
        Client GetClientFromUserEmail(object userEmail);
        ClientSoftware GetClientSoftware(int clientId, int softwareId);
    }
}
