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
                var software = _serviceManager.SoftwareService.CheckSoftwarePackage(packageId);
                var client = _serviceManager.ClientService.GetClientFromUserEmail(HttpContext.Request.Headers["Authorization"][0]);
                var clientSoftware = _serviceManager.ClientService.GetClientSoftware(client.Id, software.Id);
                _serviceManager.ClientService.ValidateChannelAvailability(software.ChannelId, client.ChannelId);
                _serviceManager.SoftwareService.ValidateSoftCounAvailability(software.Id, client.CountryId);
                var desiredSoftware = _serviceManager.SoftwareService.ValidateVersion(software, version);
                _serviceManager.SoftwareService.UpdateClientSoftware(software.Id, desiredSoftware.Id, client.Id);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new { message = ex.Message });
            }

            return Ok("{ \"message\": \"Your package was successfully updated\" }");
        }
    }
}