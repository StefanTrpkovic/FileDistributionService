namespace Services.Abstractions
{
    public interface IChannelService
    {
        void ValidateChannelAvailability(int softwareId, int channelId);
    }
}
