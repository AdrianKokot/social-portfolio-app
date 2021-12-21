using System.Text.Json;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Sociussion.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class ApiController : ControllerBase
{
    protected ulong GetUserId() => ulong.Parse(User.Identity.GetUserId());
    protected BadRequestObjectResult BadApiRequest(string key, string message)
    {
        return BadApiRequest(key, new[] {message});
    }

    protected BadRequestObjectResult BadApiRequest(string key, string[] messages)
    {
        key = JsonNamingPolicy.CamelCase.ConvertName(key);
            
        var errors = new Dictionary<string, string[]> {{key, messages}};

        return BadRequest(new ValidationProblemDetails(errors));
    }
}