using System.Xml.Serialization;

namespace RedirectService.Configuration
{
    public class RedirectRule
    {
        [XmlAttribute("from")]
        public string From{ get; set; }

        [XmlAttribute("to")]
        public string To { get; set; }

        [XmlArray("replaces")]
        [XmlArrayItem("rule")]
        public ReplaceRule[] Replaces { get; set; }
    }
}