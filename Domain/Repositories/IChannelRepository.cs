using Domain.Entities;

namespace Domain.Repositories
{
    public interface IChannelRepository
    {
        SoftwareChannel ValidateChannelAvailability(int softwareId, int channelId);
    }
}
