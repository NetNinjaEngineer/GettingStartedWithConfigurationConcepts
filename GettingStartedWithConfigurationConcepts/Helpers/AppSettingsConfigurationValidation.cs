using Microsoft.Extensions.Options;

namespace GettingStartedWithConfigurationConcepts.Helpers
{
    public class AppSettingsConfigurationValidation(
        IOptions<AppSettings> appSettingsOptions) : IValidateOptions<AppSettings>
    {
        private readonly AppSettings _appSettings = appSettingsOptions.Value;

        public ValidateOptionsResult Validate(string? name, AppSettings options)
        {
            if (string.IsNullOrEmpty(_appSettings.Environment))
                return ValidateOptionsResult.Fail("Environment is Required.");

            if (string.IsNullOrEmpty(_appSettings.Version))
                return ValidateOptionsResult.Fail("Version is Required.");

            return ValidateOptionsResult.Success;

        }
    }
}
