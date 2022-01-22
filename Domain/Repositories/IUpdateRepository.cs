using Domain.Entities;

namespace Domain.Repositories
{
    public interface IUpdateRepository
    {
        Software CheckSoftwarePackage(string packageId);
    }
}
