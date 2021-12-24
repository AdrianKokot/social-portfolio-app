using System.Text.Json;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Sociussion.Application.Common.Exceptions;
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

    protected async Task<IActionResult> ApiExceptionHandler(Func<Task<IActionResult>> fn)
    {
        try
        {
            return await fn();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

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