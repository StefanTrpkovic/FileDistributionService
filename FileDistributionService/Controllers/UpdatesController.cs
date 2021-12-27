using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FileDistributionService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdatesController : ControllerBase
    {
        private readonly IUpdates _updates;
        public UpdatesController(IUpdates updates)
        {
            _updates = updates;
        }

        [HttpGet("GetAvailableUpdates")]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult GetAvailableUpdates(string packageId, int version)
        {
            var client = _updates.GeClientFromUserEmail(HttpContext.Request.Headers["Authorization"][0]);

            var software = _updates.CheckSoftwarePackage(packageId);

            var clientSoftwareVersion = _updates.GetClientSoftwareVersion(client.Id, software.Id);

            var versionCode = _updates.GetVersionCode(version, clientSoftwareVersion.VersionId);

            var clientSoftware = _updates.GetClientSoftwareVersion(clientSoftwareVersion.SoftwareId);

            var highestSoftwareVersion = _updates.GetHighestSoftwareVersion(versionCode, clientSoftwareVersion.SoftwareId);

            return Ok();
        }
    }
}
