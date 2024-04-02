
using GettingStartedWithConfigurationConcepts.Helpers;
using Microsoft.Extensions.Options;

namespace GettingStartedWithConfigurationConcepts
{
    public class ValidationOptionsBackgroundService(
        ILogger<ValidationOptionsBackgroundService> logger,
        IHostApplicationLifetime applicationLifetime,
        IOptions<AppSettings> appsettingsOptions) : BackgroundService
    {
        private readonly ILogger<ValidationOptionsBackgroundService> _logger = logger;
        private readonly IHostApplicationLifetime _applicationLifetime = applicationLifetime;
        private readonly IOptions<AppSettings> _appsettingsOptions = appsettingsOptions;

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                var appsettingsSection = _appsettingsOptions.Value;
            }
            catch (OptionsValidationException ex)
            {
                _logger.LogError("One or more validation options checks fails !!!");

                foreach (var failure in ex.Failures)
                    _logger.LogError(failure);

                _applicationLifetime.StopApplication();

            }

            return Task.CompletedTask;

        }

    }
}
