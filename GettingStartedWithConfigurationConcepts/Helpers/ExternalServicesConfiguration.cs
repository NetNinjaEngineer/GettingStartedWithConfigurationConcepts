using System.ComponentModel.DataAnnotations;

namespace GettingStartedWithConfigurationConcepts.Helpers
{
    public class ExternalServicesConfiguration
    {
        [Required]
        public string? Url { get; set; }

        public int MinsToCache { get; set; }
    }
}
