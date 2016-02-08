using System.Xml.Serialization;

namespace RedirectService.Configuration
{
    public class ReplaceRule
    {
        [XmlAttribute("mediaType")]
        public string MediaType { get; set; }

        [XmlAttribute("patterns")]
        public string Patterns { get; set; }
    }
}