using Domain.Entities;
using Domain.Repositories;

namespace Persistence.Repositories
{
    internal class UpdateRepository : IUpdateRepository
    {
        private readonly RepositoryDbContext _dbContext;

        public UpdateRepository(RepositoryDbContext dbContext) => _dbContext = dbContext;

        public void UpdateClientSoftware(int softwareId, int desiredSoftwareId, int clientId)
        {
            var record = _dbContext.ClientSoftware.FirstOrDefault(x => x.ClientId == clientId && x.SoftwareId == softwareId);

            if (record != null)
            {
                _dbContext.ClientSoftware.Remove(record);

                var cs = new ClientSoftware();
                cs.ClientId = clientId;
                cs.SoftwareId = desiredSoftwareId;
                _dbContext.ClientSoftware.Add(cs);
                _dbContext.SaveChanges();
            }

        }
    }
}
