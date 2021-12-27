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
        int GetVersionCode(int version, int versionId);
        int GetHighestSoftwareVersion(int versionCode, int softwareId);
        ICollection<SoftwareVersion> GetClientSoftwareVersion(int softwareId);       
    }
}
