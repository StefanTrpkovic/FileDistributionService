using Domain.Entities;

namespace Services.Abstractions
{
    public interface IVersionService
    {
        void ValidateVersion(ClientSoftwareVersion clientSoftwareVersion, int version);
    }
}
