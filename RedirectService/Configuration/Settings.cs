using System.Xml.Serialization;

namespace RedirectService.Configuration
{
    [XmlRoot("settings")]
    public class Settings
    {
        [XmlArray("patterns")]
        [XmlArrayItem("pattern")]
        public Pattern[] Patterns { get; set; }

        [XmlArray("redirects")]
        [XmlArrayItem("redirect")]
        public RedirectRule[] Redirects { get; set; }
    }
}