using System.Xml.Serialization;

namespace RedirectService.Configuration
{
    public class Pattern
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("regex")]
        public string Regex { get; set; }

        [XmlAttribute("replacement")]
        public string Replacement { get; set; }
    }
}