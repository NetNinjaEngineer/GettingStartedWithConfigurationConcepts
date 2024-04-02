using System.ComponentModel.DataAnnotations;

namespace GettingStartedWithConfigurationConcepts.Helpers
{
    public class AppSettings
    {
        public string? Version { get; set; }

        [Required]
        public string? Environment { get; set; }

        public FeatureFlags FeatureFlags { get; set; }
    }
}
