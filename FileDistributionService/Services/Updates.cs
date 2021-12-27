using FileDistributionService.Data;
using FileDistributionService.Entity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Version = FileDistributionService.Entity.Version;

namespace FileDistributionService.Services
{
    public class Updates : IUpdates
    {
        private readonly DataContext _dataContext;
        public Updates(DataContext dataContext)
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
                throw new BadHttpRequestException("Please insert a valid package id", 404);

            return software;
        }

        public ClientSoftwareVersion GetClientSoftwareVersion(int clientId, int softwareId)
        {
            var clientSoftwareVersion = _dataContext.ClientSoftwareVersion.FirstOrDefault(x => x.ClientId == clientId && x.SoftwareId == softwareId);

            if (clientSoftwareVersion == null)
                throw new BadHttpRequestException("The specified client hasn't installed the requested package previosuly");

            return clientSoftwareVersion;
        }

        public void ValidateSoftCounAvailability(int softwareId, int countryId)
        {
            if(!_dataContext.SoftwareCountry.Any(x => x.SoftwareId == softwareId && x.CountryId == countryId))
                throw new BadHttpRequestException("The software is not available for your country");
        }

        public void ValidateVersion(ClientSoftwareVersion clientSoftwareVersion, int version)
        {
            var versionCode = _dataContext.Version.FirstOrDefault(y => y.Id == clientSoftwareVersion.VersionId);

            if (version == versionCode?.VersionCode)
                throw new BadHttpRequestException("You already have that version installed of the package");

            if (version < versionCode?.VersionCode)
                throw new BadHttpRequestException("You have a newer version installed of the package");

            if ((version-versionCode?.VersionCode) > 1)
                throw new BadHttpRequestException("You can not skip versions. You must ask for the next version from the one you already have");
        }

        public void ValidateChannelAvailability(int softwareId, int channelId)
        {
            var softChannel = _dataContext.SoftwareChannel.FirstOrDefault(y => y.ChannelId == channelId && y.SoftwareId == softwareId);

            if (softChannel == null)
                throw new BadHttpRequestException("This software is not in the channel you subscribed");
        }

        public void ValidateDateAvailability(int softwareId, int version)
        {
            var softChannel = _dataContext.SoftwareVersion.FirstOrDefault(y => y.SoftwareId == softwareId && y.VersionId == version);

            if (softChannel != null)
            {
                if (softChannel.ReleaseDate > DateTime.Now)
                    throw new BadHttpRequestException("This software has still not been released for update");
            }
        }
    }
}
