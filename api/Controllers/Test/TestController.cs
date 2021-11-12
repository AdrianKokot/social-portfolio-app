using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Sociussion.Configuration;
using Sociussion.Services.Token;

namespace Sociussion.Controllers.Test
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public TestController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public ActionResult<TokenConfiguration> GetTest()
        {
            try
            {
                var r = _configuration.GetTokenConfiguration();
                return Ok(r);
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }

        [HttpGet("authorized")]
        [Authorize]
        public ActionResult<string[]> GetAuthorizedTest()
        {
            var result = new string[] {"testAuthorized", "test2Authorized", "test3Authorized"};

            return Ok(result);
        }
    }
}
