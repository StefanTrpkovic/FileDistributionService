using Domain.Entities;

namespace Services.Abstractions
{
    public interface IUpdateService 
    {
        Software CheckSoftwarePackage(string packageId);
    }
}
