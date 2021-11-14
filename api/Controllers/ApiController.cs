using System.Collections.Generic;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace Sociussion.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public abstract class ApiController : ControllerBase
    {
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
}
