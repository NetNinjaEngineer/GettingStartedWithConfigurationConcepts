using GettingStartedWithConfigurationConcepts.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace GettingStartedWithConfigurationConcepts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionsController : ControllerBase
    {
        private readonly AppSettings _appSettings;

        public OptionsController(IOptions<AppSettings> options)
        {
            _appSettings = options.Value;
        }

        [HttpGet("GetEnviromentByOptionsPattern")]
        public IActionResult GetEnviromentByOptionsPattern()
        {
            var version = _appSettings.Version;
            var environment = _appSettings.Environment;
            return Ok(environment);
        }

    }
}
