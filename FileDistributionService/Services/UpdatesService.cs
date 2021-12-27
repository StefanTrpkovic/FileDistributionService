using FileDistributionService.Data;
using FileDistributionService.Entity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace FileDistributionService.Services
{
    public class UpdatesService : IUpdates
    {
        private readonly DataContext _dataContext;
        public UpdatesService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Client GeClientFromUserEmail(string bearerToken)
        {
            var token = new JwtSecurityTokenHandler().ReadJwtToken(bearerToken.Replace("Bearer ", ""));
            var userEmail = token.Payload.ToArray()[2].Value;

            return _dataContext.Client.First(x => x.Email.Equals(userEmail));
        }

        public Software CheckSoftwarePackage(string packageId)
        {
            var software = _dataContext.Software.FirstOrDefault(x => x.PackageVersion.ToString().Equals(packageId));

            if (software == null)
                throw new BadHttpRequestException("Please insert a valid package id");

            return software;
        }

        public ClientSoftwareVersion GetClientSoftwareVersion(int clientId, int softwareId)
        {
            var clientSoftwareVersion = _dataContext.ClientSoftwareVersion.First(x => x.ClientId == clientId && x.SoftwareId == softwareId);

            if (clientSoftwareVersion == null)
                throw new BadHttpRequestException("The specified client hasn't installed the requested package previosuly");

            return clientSoftwareVersion;
        }

        public int GetVersionCode(int version, int versionId)
        {
            var versionCode = _dataContext.Version.First(x => x.Id == versionId).VersionCode;

            if (versionCode == version)
                throw new BadHttpRequestException("You already have the requested update");

            return versionCode;
        }

        public int GetHighestSoftwareVersion(int versionCode, int softwareId)
        {
            var highestSoftwareVersion = _dataContext.SoftwareVersion.Where(x => x.SoftwareId == softwareId).Join(_dataContext.Version, sv => sv.VersionId, v => v.Id, (sv, v) => v.VersionCode).First();

            if (highestSoftwareVersion == versionCode)
                throw new BadHttpRequestException("You already have the newest update");

            return highestSoftwareVersion;
        }

        public ICollection<SoftwareVersion> GetClientSoftwareVersion(int softwareId)
        {
            return _dataContext.SoftwareVersion.Where(x => x.SoftwareId == softwareId).ToList();
        }
    }
}
