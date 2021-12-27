using FileDistributionService.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace FileDistributionService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdatesController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public UpdatesController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet("GetAvailableUpdates")]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetAvailableUpdates(string packageId, string version)
        {
            var bearerToken = HttpContext.Request.Headers["Authorization"][0];
            var token = new JwtSecurityTokenHandler().ReadJwtToken(bearerToken.Replace("Bearer ", ""));
            var userEmail = token.Payload.ToArray()[2].Value;

            var client = _dataContext.Client.First(x => x.Email.Equals(userEmail));
            var software = _dataContext.Software.FirstOrDefault(x => x.PackageVersion.ToString().Equals(packageId));

            if (software == null)
                return NotFound("Please insert a valid package id");

            var clientSoftwareVersion = _dataContext.ClientSoftwareVersion.First(x => x.ClientId == client.Id && x.SoftwareId == software.Id);

            if (clientSoftwareVersion == null)
                return NotFound("The specified client hasn't installed the requested package previosuly");

            var versionCode = _dataContext.Version.First(x => x.Id == clientSoftwareVersion.VersionId).VersionCode;

            var clientSoftware = _dataContext.SoftwareVersion.Where(x => x.SoftwareId == clientSoftwareVersion.SoftwareId).OrderByDescending(y => y.VersionId).First().;

            if(versionCode == )





            return Ok();
        }
    }
}
