using System.Configuration;

namespace RedirectService
{
    public class GlobalSection : ConfigurationSection
    {
        [ConfigurationProperty("serviceName", IsRequired = true)]
        public string ServiceName => (string)this["serviceName"];

        [ConfigurationProperty("displayName", IsRequired = true)]
        public string DisplayName => (string)this["displayName"];

        [ConfigurationProperty("description", IsRequired = true)]
        public string Description => (string)this["description"];
    }
}