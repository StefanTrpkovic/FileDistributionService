using Domain.Entities;
using Domain.Repositories;

namespace Persistence.Repositories
{
    internal class ClientRepository : IClientRepository
    {
        private readonly RepositoryDbContext _dbContext;

        public ClientRepository(RepositoryDbContext dbContext) => _dbContext = dbContext;

        public Client GetClientFromUserEmail(object userEmail) =>
            _dbContext.Client.First(x => x.Email.Equals(userEmail));

        public ClientSoftware GetClientSoftware(int clientId, int softwareId) =>
            _dbContext.ClientSoftware.FirstOrDefault(x => x.ClientId == clientId && x.SoftwareId == softwareId);
        
    }
}
