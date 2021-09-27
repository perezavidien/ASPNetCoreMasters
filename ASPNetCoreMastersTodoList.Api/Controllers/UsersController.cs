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

namespace ASPNetCoreMastersTodoList.Api.Controllers
{
    public class UsersController : Controller
    {

        private IConfiguration _config;
        public IOptions<Authentication> _authSettings;

        public UsersController(IConfiguration config, IOptions<Authentication> authSettings)
        {
            _config = config;
            _authSettings = authSettings;
        }

        [HttpPost]
        public IActionResult Login()
        {
            var tokenString = Encoding.ASCII.GetBytes(_authSettings.Value.Jwt.SecurityKey);

            return Ok(new { token = tokenString });
        }
    }
}
