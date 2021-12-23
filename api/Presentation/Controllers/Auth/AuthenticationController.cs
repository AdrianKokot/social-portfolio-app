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
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AuthenticationController(
        UserManager<ApplicationUser> userManager,
        ITokenService tokenService,
        SignInManager<ApplicationUser> signInManager) : base(userManager)
    {
        _userManager = userManager;
        _tokenService = tokenService;
        _signInManager = signInManager;
    }


    [HttpPost]
    [Route("register")]
    public async Task<ActionResult> Register([FromBody] RegisterUserModel model)
    {
        var userExists = await _userManager.FindByEmailAsync(model.Email);

        if (userExists != null)
            return ApiValidationError(nameof(model.Email), "Given e-mail address is already taken");


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

        return ApiValidationError(nameof(model.Password), errors);
    }


    [HttpPost]
    [Route("login")]
    public async Task<ActionResult> Login([FromBody] LoginUserModel model)
    {
        var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, true, false);

        if (!result.Succeeded)
        {
            return ApiValidationError(nameof(model.Password), "Invalid credentials");
        }
        
        var user = await _userManager.FindByEmailAsync(model.Email);
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
}