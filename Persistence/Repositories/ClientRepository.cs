using Domain.Entities;
using Domain.Repositories;

namespace Persistence.Repositories
{
    internal class ClientRepository : IClientRepository
    {
        private readonly RepositoryDbContext _dbContext;

        public ClientRepository(RepositoryDbContext dbContext) => _dbContext = dbContext;

        public Client GeClientFromUserEmail(object userEmail) =>
            _dbContext.Client.First(x => x.Email.Equals(userEmail));

        public ClientSoftwareVersion GetClientSoftwareVersion(int clientId, int softwareId) =>
            _dbContext.ClientSoftwareVersion.FirstOrDefault(x => x.ClientId == clientId && x.SoftwareId == softwareId);
        
    }
}
