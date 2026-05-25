using Microsoft.AspNetCore.Mvc;

namespace Practical_16.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloController : ControllerBase
    {
        private readonly ILogger<HelloController> _logger;
        private readonly IWebHostEnvironment _environment;
        public HelloController(ILogger<HelloController> logger, IWebHostEnvironment environment)
        {
            _logger = logger;
            _environment = environment;
        }

        [HttpGet]
        public string Get()
        {
            _logger.LogInformation("Hello API was called");
            return "Hello World";
        }
        [HttpGet("environment")]
        public string GetEnvironment()
        {
            return $"Current Environment {_environment.EnvironmentName}";
        }
    }
}
