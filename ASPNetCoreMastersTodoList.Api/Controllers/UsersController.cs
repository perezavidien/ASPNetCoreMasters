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
using ASPNetCoreMastersTodoList.Api.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;

namespace ASPNetCoreMastersTodoList.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DotNetMastersDB _dbContext;
        private IConfiguration _config;
        //private IAuthorizationService _authService;
        private IOptions<Authentication> _authSettings;
        private UserManager<IdentityUser> _userManager;

        public UsersController(
            IConfiguration config,
            IAuthorizationService _authService,
            IOptions<Authentication> authSettings,
            DotNetMastersDB dbContext,
            UserManager<IdentityUser> userManager)
        {
            _config = config;
            _authSettings = authSettings;
            _dbContext = dbContext;
            _userManager = userManager;

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
        public async Task<IActionResult> Register(RegisterBindingModel model)
        {
            var user = new IdentityUser
            {
                Email = model.Email,
                UserName = model.Email //remove "@..."
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, err.Description);
                }
                return BadRequest(ModelState);
            }

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            token = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));

            return Ok(new
            {
                token = token,
                email = model.Email
            });
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
