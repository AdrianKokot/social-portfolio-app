using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sociussion.Application.Authentication;
using Sociussion.Application.Common.Interfaces;
using Sociussion.Domain.Entities;

namespace Sociussion.Presentation.Controllers.Auth;

[AllowAnonymous]
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
            Name = model.Name,
            Email = model.Email,
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = model.Email
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
                new AuthenticatedUserModel
                {
                    Token = await _tokenService.CreateJwtToken(user),
                    Email = user.Email,
                    Name = user.Name,
                    Id = user.Id
                }
            );
        }

        return BadApiRequest(nameof(model.Password), "Invalid credentials");
    }
}