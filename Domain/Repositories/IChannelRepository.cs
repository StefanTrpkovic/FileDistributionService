using Domain.Entities;

namespace Domain.Repositories
{
    public interface IChannelRepository
    {
        Software ValidateChannelAvailability(int softwareId, int channelId);
    }
}
