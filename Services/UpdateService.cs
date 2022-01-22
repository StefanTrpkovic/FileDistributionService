using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using Services.Abstractions;

namespace Services
{
    internal class UpdateService : IUpdateService
    {
        private readonly IRepositoryManager _repositoryManager;

        public UpdateService(IRepositoryManager repositoryManager) => _repositoryManager = repositoryManager;

        public Software CheckSoftwarePackage(string packageId)
        {
            var result = _repositoryManager.UpdateRepository.CheckSoftwarePackage(packageId);

            if (result == null)
                throw new ValidPackageException();

            return result;
        }
    }
}
