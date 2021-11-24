using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sociussion.Data.Models;
using Sociussion.Data.Models.Authentication;
using Sociussion.Services.Token;

namespace Sociussion.Controllers.Authentication
{
    public class AuthenticationController : ApiController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenService _tokenService;

        public AuthenticationController(
            UserManager<ApplicationUser> userManager,
            ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Register([FromBody] RegisterUserModel model)
        {
            var userExists = await _userManager.FindByEmailAsync(model.Email);

            if (userExists != null)
                return BadApiRequest(nameof(model.Email), "Given e-mail address is already taken");


            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email, SecurityStamp = Guid.NewGuid().ToString(), UserName = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);


            if (result.Succeeded)
            {
                return NoContent();
            }

            var errors = result.Errors
                .Select(x => x.Description.Replace("Passwords", "Password"))
                .ToArray();
            
            return BadApiRequest(nameof(model.Password), errors);
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login([FromBody] LoginUserModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                return Ok(
                    new AuthenticatedUserModel {Token = await _tokenService.CreateJwtToken(user), Email = user.Email}
                );
            }

            return BadApiRequest(nameof(model.Password), "Invalid credentials");
        }
    }
}
