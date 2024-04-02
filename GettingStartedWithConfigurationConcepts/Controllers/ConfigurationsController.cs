using Microsoft.AspNetCore.Mvc;

namespace GettingStartedWithConfigurationConcepts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationsController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ConfigurationsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("GetAppsettingsSection")]
        public IActionResult GetAppsettingsSection()
        {
            var appsettingsSection = _configuration.GetSection("AppSettings");
            var appVersion = appsettingsSection.GetValue<string>("version");
            return Ok(appVersion);
        }

        [HttpGet("GetSingleConfigValue")]
        public IActionResult GetSingleConfigValue()
        {
            var environment = _configuration.GetValue<string>("AppSettings:Environment");
            return Ok(environment);
        }

        [HttpGet("GeNestedSection")]
        public IActionResult GetNestedSection()
        {
            var featuresFlagSection = _configuration.GetSection("AppSettings:FeatureFlags");
            var newUserRegistration = featuresFlagSection["NewUserRegistration"];
            return Ok(newUserRegistration);
        }
    }
}
