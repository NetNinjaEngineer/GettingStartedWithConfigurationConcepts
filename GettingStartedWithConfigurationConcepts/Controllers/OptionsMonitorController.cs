using GettingStartedWithConfigurationConcepts.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace GettingStartedWithConfigurationConcepts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionsMonitorController(IOptionsMonitor<AppSettings> optionsMonitor) : ControllerBase
    {
        //private readonly AppSettings _appSettings = optionsMonitor.CurrentValue;
        private readonly IOptionsMonitor<AppSettings> _optionsMonitor = optionsMonitor;

        [HttpGet]
        public IActionResult Get()
        {
            var featuresFlag = _optionsMonitor.CurrentValue.FeatureFlags;
            var advancedSearch = featuresFlag.AdvancedSearch;
            return Ok(advancedSearch);
        }

    }
}
