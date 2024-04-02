using GettingStartedWithConfigurationConcepts.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace GettingStartedWithConfigurationConcepts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionsController(IOptions<AppSettings> options) : ControllerBase
    {
        private readonly AppSettings _appSettings = options.Value;

        [HttpGet("GetEnviromentByOptionsPattern")]
        public IActionResult GetEnviromentByOptionsPattern()
        {
            var version = _appSettings.Version;
            var environment = _appSettings.Environment;
            return Ok(environment);
        }


        [HttpGet("GetNestedSectionUsingOptions")]
        public IActionResult GetNestedSectionUsingOptions()
        {
            var featuresFlagSection = _appSettings.FeatureFlags;
            var newUserRegisteration = featuresFlagSection.NewUserRegistration;
            return Ok(newUserRegisteration);
        }

    }
}
