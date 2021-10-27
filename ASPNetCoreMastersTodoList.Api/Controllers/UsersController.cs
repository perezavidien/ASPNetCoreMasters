using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Text;
using Microsoft.Extensions.Options;
using ASPNetCoreMastersTodoList.Api.Helpers;
using Microsoft.AspNetCore.Authorization;
using ASPNetCoreMastersTodoList.Api.Data;

namespace ASPNetCoreMastersTodoList.Api.Controllers
{
    public class UsersController : Controller
    {
        private readonly DotNetMastersDB _dbContext;
        private IConfiguration _config;
        //private IAuthorizationService _authService;
        private IOptions<Authentication> _authSettings;

        public UsersController(
            IConfiguration config, 
            IAuthorizationService _authService, 
            IOptions<Authentication> authSettings,
            DotNetMastersDB dbContext)
        {
            _config = config;
            _authSettings = authSettings;
            _dbContext = dbContext;
        }

        [HttpPost]
        [Authorize]
        public IActionResult Login()
        {
            var tokenString = Encoding.ASCII.GetBytes(_authSettings.Value.Jwt.SecurityKey);

            return Ok(new { token = tokenString });
        }

        [HttpPost]
        [Authorize]
        public IActionResult Register()
        {
            // todo
            return Ok();
        }

        [HttpPost]
        [Authorize]
        public IActionResult ConfirmEmail()
        {
            // todo
            return Ok();
        }

    }
}
