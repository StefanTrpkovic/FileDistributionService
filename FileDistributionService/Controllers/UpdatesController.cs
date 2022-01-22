using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using System.Net;

namespace FileDistributionService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdatesController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public UpdatesController(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpGet("GetAvailableUpdates")]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult GetAvailableUpdates(string packageId, int version)
        {
            try
            {
                var software = _serviceManager.UpdateService.CheckSoftwarePackage(packageId);
                var client = _serviceManager.ClientService.GeClientFromUserEmail(HttpContext.Request.Headers["Authorization"][0]);
                var clientSoftware = _serviceManager.ClientService.GetClientSoftware(client.Id, software.Id);
                _serviceManager.SoftwareService.ValidateVersion(clientSoftware, version);
                _serviceManager.SoftwareService.ValidateSoftCounAvailability(software.Id, client.CountryId);
                _serviceManager.ChannelService.ValidateChannelAvailability(software.Id, client.ChannelId);
                _serviceManager.SoftwareService.ValidateDateAvailability(software.Id, version);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = ex.Message });
            }

            return Ok("Your package will start downloading now");
        }
    }
}