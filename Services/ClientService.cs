using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using Services.Abstractions;
using System.IdentityModel.Tokens.Jwt;

namespace Services
{
    internal class ClientService : IClientService
    {
        private readonly IRepositoryManager _repositoryManager;

        public ClientService(IRepositoryManager repositoryManager) => _repositoryManager = repositoryManager;

        public Client GeClientFromUserEmail(string bearerToken)
        {
            var token = new JwtSecurityTokenHandler().ReadJwtToken(bearerToken.Replace("Bearer ", ""));
            var userEmail = token.Payload.ToArray()[2].Value;

            return _repositoryManager.ClientRepository.GeClientFromUserEmail(userEmail);
        }

        public ClientSoftware GetClientSoftware(int clientId, int softwareId)
        {
            var result = _repositoryManager.ClientRepository.GetClientSoftware(clientId, softwareId);

            if (result == null)
                throw new ClientSoftwareException();

            return result;
        }
    }
}
