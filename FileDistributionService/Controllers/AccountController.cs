using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FileDistributionService.Models;
using System.Collections.Generic;
using System;
using System.Linq;

namespace FileDistributionService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly JwtSettings jwtSettings;
        public AccountController(JwtSettings jwtSettings)
        {
            this.jwtSettings = jwtSettings;
        }
        private IEnumerable<Users> logins = new List<Users>() {
            new Users() {
                    Id = Guid.NewGuid(),
                        EmailId = "stefan.trpkovic@gmail.com",
                        UserName = "admin",
                        Password = "admin",
                },
                new Users() {
                    Id = Guid.NewGuid(),
                        EmailId = "anders.hansen@gmail.com",
                        UserName = "anders",
                        Password = "anders1",
                },
                new Users() {
                    Id = Guid.NewGuid(),
                        EmailId = "fabricio.bianchi@gmail.com",
                        UserName = "fabricio",
                        Password = "fabi1",
                },
                new Users() {
                    Id = Guid.NewGuid(),
                        EmailId = "andy.smith@gmail.com",
                        UserName = "andy",
                        Password = "andy1",
                },
                new Users() {
                    Id = Guid.NewGuid(),
                        EmailId = "jan.vrba@gmail.com",
                        UserName = "jan",
                        Password = "jan1",
                },
                new Users() {
                    Id = Guid.NewGuid(),
                        EmailId = "alex.sidorov@gmail.com",
                        UserName = "alex",
                        Password = "alex1",
                }
        };
        [HttpPost]
        public IActionResult GetToken(UserLogins userLogins)
        {
            try
            {
                var Token = new UserTokens();
                var Valid = logins.Any(x => x.UserName.Equals(userLogins.UserName, StringComparison.OrdinalIgnoreCase));
                if (Valid)
                {
                    var user = logins.FirstOrDefault(x => x.UserName.Equals(userLogins.UserName, StringComparison.OrdinalIgnoreCase));
                    Token = JwtHelpers.JwtHelpers.GenTokenkey(new UserTokens()
                    {
                        EmailId = user.EmailId,
                        GuidId = Guid.NewGuid(),
                        UserName = user.UserName,
                        Id = user.Id,
                    }, jwtSettings);
                }
                else
                {
                    return BadRequest($"wrong password");
                }
                return Ok(Token);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// Get List of UserAccounts
        /// </summary>
        /// <returns>List Of UserAccounts</returns>
        [HttpGet]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult GetList()
        {
            return Ok(logins);
        }
    }
}
