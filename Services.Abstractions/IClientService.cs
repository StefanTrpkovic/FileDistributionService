using Domain.Entities;

namespace Services.Abstractions
{
    public interface IClientService
    {
        Client GeClientFromUserEmail(string bearerToken);
        ClientSoftware GetClientSoftware(int clientId, int softwareId);
    }
}
