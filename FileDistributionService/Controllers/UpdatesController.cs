using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
            try
            {
                var software = _updates.CheckSoftwarePackage(packageId);

                var client = _updates.GeClientFromUserEmail(HttpContext.Request.Headers["Authorization"][0]);

                var clientSoftwareVersion = _updates.GetClientSoftwareVersion(client.Id, software.Id);

                _updates.ValidateVersion(clientSoftwareVersion, version);

                _updates.ValidateSoftCounAvailability(software.Id, client.CountryId);

                _updates.ValidateChannelAvailability(software.Id, client.ChannelId);

                _updates.ValidateDateAvailability(software.Id, version);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = ex.Message });
            }

            return Ok("Your package will start downloading now");
        }
    }
}
