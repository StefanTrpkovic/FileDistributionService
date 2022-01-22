using Domain.Exceptions;
using Domain.Repositories;
using Services.Abstractions;

namespace Services
{
    internal class ChannelService : IChannelService
    {
        private readonly IRepositoryManager _repositoryManager;

        public ChannelService(IRepositoryManager repositoryManager) => _repositoryManager = repositoryManager;

        public void ValidateChannelAvailability(int softwareId, int channelId)
        {
            var softChannel = _repositoryManager.ChannelRepository.ValidateChannelAvailability(softwareId, channelId);

            if (softChannel == null)
                throw new ChannelSoftwareException();
        }
    }
}
