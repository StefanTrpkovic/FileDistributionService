using Domain.Entities;

namespace Services.Abstractions
{
    public interface IClientService
    {
        Client GetClientFromUserEmail(string bearerToken);
        ClientSoftware GetClientSoftware(int clientId, int softwareId);
        void ValidateChannelAvailability(int softwareId, int channelId);
    }
}
