using System.Xml.Serialization;

namespace RedirectService.Configuration
{
    public class Pattern
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("from")]
        public string From { get; set; }

        [XmlAttribute("to")]
        public string To { get; set; }
    }
}