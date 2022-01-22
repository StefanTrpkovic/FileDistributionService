using Domain.Entities;

namespace Services.Abstractions
{
    public interface IClientService
    {
        Client GeClientFromUserEmail(string bearerToken);
        ClientSoftwareVersion GetClientSoftwareVersion(int clientId, int softwareId);
    }
}
