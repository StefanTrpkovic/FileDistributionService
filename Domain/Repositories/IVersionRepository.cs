using Domain.Entities;
using Version = Domain.Entities.Version;

namespace Domain.Repositories
{
    public interface IVersionRepository
    {
        Version ValidateVersion(ClientSoftwareVersion clientSoftwareVersion);
    }
}
