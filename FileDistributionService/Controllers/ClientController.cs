using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileDistributionService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        [HttpGet(Name = "GetAvailableUpdates")]
        public async Task<IActionResult> Get(string packageId, string version)
        {
            return Ok();
        }
    }
}
