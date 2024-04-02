using GettingStartedWithConfigurationConcepts.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace GettingStartedWithConfigurationConcepts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherForecastController(
        HttpClient httpClient,
        ILogger<WeatherForecastController> logger,
        IOptionsMonitor<ExternalServicesConfiguration> optionsMonitor) : ControllerBase
    {
        private readonly HttpClient _httpClient = httpClient;
        private readonly ILogger<WeatherForecastController> _logger = logger;
        private readonly ExternalServicesConfiguration _externalServiceConfig = optionsMonitor.Get(Constants.WeatherApi);

        [HttpGet]
        public IActionResult Get()
        {
            var _minsToCache = _externalServiceConfig.MinsToCache;
            var _weatherForecastUrl = _externalServiceConfig.Url!;
            return Ok(_weatherForecastUrl);
        }

    }
}
