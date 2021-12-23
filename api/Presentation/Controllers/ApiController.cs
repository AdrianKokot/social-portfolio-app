using System.Text.Json;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Sociussion.Domain.Entities;

namespace Sociussion.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class ApiController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;

    protected ApiController(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    protected ulong GetUserId()
    {
        return ulong.Parse(_userManager.GetUserId(User));
    }

    // protected BadRequestObjectResult ValidationError()
    // {
    //     
    // }

    protected BadRequestObjectResult ApiValidationError(string key, string message)
    {
        return ApiValidationError(key, new[] {message});
    }

    protected BadRequestObjectResult ApiValidationError(ModelStateDictionary modelState)
    {
        return BadRequest(new ValidationProblemDetails(modelState));
    }

    protected BadRequestObjectResult ApiValidationError(string key, string[] messages)
    {
        key = JsonNamingPolicy.CamelCase.ConvertName(key);

        var errors = new Dictionary<string, string[]> {{key, messages}};

        return BadRequest(new ValidationProblemDetails(errors));
    }
}