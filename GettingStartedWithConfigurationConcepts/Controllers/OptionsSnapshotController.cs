using GettingStartedWithConfigurationConcepts.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace GettingStartedWithConfigurationConcepts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionsSnapshotController : ControllerBase
    {
        private readonly AppSettings _appSettings;

        public OptionsSnapshotController(IOptionsSnapshot<AppSettings> optionsSnapshot)
        {
            _appSettings = optionsSnapshot.Value;
        }

        [HttpGet("ReloadConfiguration")]
        public IActionResult ReloadConfiguration()
        {
            var newUserRegisteration = _appSettings.FeatureFlags.NewUserRegistration;
            return Ok(newUserRegisteration);
        }
    }
}
