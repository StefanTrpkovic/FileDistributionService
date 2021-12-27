using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace FileDistributionService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        [HttpGet]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetAvailableUpdates(string packageId, string version)
        {
            var bearerToken = HttpContext.Request.Headers["Authorization"][0];
            var token = new JwtSecurityTokenHandler().ReadJwtToken(bearerToken.Replace("Bearer ", ""));

            var userEmail = token.Payload.ToArray()[2].Value;

            return Ok();
        }
    }
}
