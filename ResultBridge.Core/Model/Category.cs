using System.Xml.Serialization;

namespace ResultBridge.Core.Model
{
    [XmlRoot(elementName: "categories")]
    public class Category
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        public Category()
        {
        }
    }
}