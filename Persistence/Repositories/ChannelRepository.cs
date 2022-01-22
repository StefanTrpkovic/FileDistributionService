using Domain.Entities;
using Domain.Repositories;

namespace Persistence.Repositories
{
    internal class ChannelRepository : IChannelRepository
    {
        private readonly RepositoryDbContext _dbContext;

        public ChannelRepository(RepositoryDbContext dbContext) => _dbContext = dbContext;

        public Software ValidateChannelAvailability(int softwareId, int channelId) =>
            _dbContext.Software.FirstOrDefault(y => y.ChannelId == channelId && y.Id == softwareId);        
    }
}
