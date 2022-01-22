using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using Services.Abstractions;

namespace Services
{
    internal class VersionService : IVersionService
    {
        private readonly IRepositoryManager _repositoryManager;

        public VersionService(IRepositoryManager repositoryManager) => _repositoryManager = repositoryManager;

        public void ValidateVersion(ClientSoftwareVersion clientSoftwareVersion, int version)
        {
            var versionCode = _repositoryManager.VersionRepository.ValidateVersion(clientSoftwareVersion);

            if (version == versionCode?.VersionCode)
                throw new SameVersionException();

            if (version < versionCode?.VersionCode)
                throw new NewerVersionException();

            if ((version - versionCode?.VersionCode) > 1)
                throw new SkipVersionException();
        }
    }
}
