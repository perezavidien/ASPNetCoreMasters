using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;
using ASPNetCoreMastersTodoList.Api.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using ASPNetCoreMastersTodoList.Api.BindingModels;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace ASPNetCoreMastersTodoList.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private JwtOptions _jwtOptions;
        private UserManager<IdentityUser> _userManager;

        public UsersController(
            IOptions<JwtOptions> JwtOptions,
            UserManager<IdentityUser> userManager)
        {
            _jwtOptions = JwtOptions.Value;
            _userManager = userManager;

        }

        [HttpPost("login")]
        [Authorize]
        public async Task<IActionResult> Login(LoginBindingModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return NotFound(new { errors = new[] { $"User with email '{model.Email}' was not found." } });
            }

            var confirmEmailResult = _userManager.CheckPasswordAsync(user, model.Password);
            if (confirmEmailResult == null)
            {
                return BadRequest(new { errors = new[] { "Invalid Password." } });
            }

            if (!user.EmailConfirmed)
            {
                return BadRequest(new { errors = new[] { "Please confirm your email first." } });
            }

            var tokenString = GenerateToken(user);
            return Ok(new { jwt = tokenString });
        }

        private string GenerateToken(IdentityUser user)
        {
            IList<Claim> userClaims = new List<Claim>
            {
                new Claim("UserName", user.UserName),
                new Claim("Email", user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            return new JwtSecurityTokenHandler().WriteToken(
                new JwtSecurityToken(
                    claims: userClaims,
                    expires: DateTime.Now.AddMinutes(10),
                    signingCredentials: new SigningCredentials(_jwtOptions.SecurityKey, SecurityAlgorithms.HmacSha256)
                    ));
        }

        [HttpPost("register")]
        [Authorize]
        public async Task<IActionResult> RegisterAsync(RegisterBindingModel model)
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

        [HttpPost("confirmEmail")]
        [Authorize]
        public async Task<IActionResult> ConfirmEmailAsync(ConfirmBindingModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            var token = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(model.Token));
            if (user == null || user.EmailConfirmed)
            {
                return BadRequest();
            }

            var confirmEmailResult = await _userManager.ConfirmEmailAsync(user, token);
            if (!confirmEmailResult.Succeeded)
            {
                return BadRequest();
            }

            return Ok("Email confirmation successful");
        }
    }
}
