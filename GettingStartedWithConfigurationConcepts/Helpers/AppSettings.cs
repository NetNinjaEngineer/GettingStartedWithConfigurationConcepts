namespace GettingStartedWithConfigurationConcepts.Helpers
{
    public class AppSettings
    {
        public string? Version { get; set; }

        public string? Environment { get; set; }

        public FeatureFlags FeatureFlags { get; set; }
    }
}
