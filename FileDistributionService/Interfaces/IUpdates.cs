using FileDistributionService.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileDistributionService
{
    public interface IUpdates
    {
        Client GeClientFromUserEmail(string bearerToken);
        Software CheckSoftwarePackage(string packageId);
        ClientSoftwareVersion GetClientSoftwareVersion(int clientId, int softwareId);
        void ValidateSoftCounAvailability(int softwareId, int countryId);
        void ValidateVersion(ClientSoftwareVersion clientSoftwareVersion, int version);
        void ValidateChannelAvailability(int softwareId, int channelId);
        void ValidateDateAvailability(int softwareId, int version);
    }
}
