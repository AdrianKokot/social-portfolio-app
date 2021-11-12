using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sociussion.Models;
using Sociussion.Models.Authentication;
using Sociussion.Services.Token;

namespace Sociussion.Controllers.Authentication
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
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
                return BadRequest("User already exists!");

            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email, SecurityStamp = Guid.NewGuid().ToString(), UserName = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
                return BadRequest("Something went wrong");

            return NoContent();
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login([FromBody] LoginUserModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                return Ok(new {token = await _tokenService.CreateJwtToken(user)});
            }

            return BadRequest("Invalid credentials.");
        }
    }
}
