using System.Collections.Generic;
using System.Xml.Serialization;
using ResultBridge.Core.Model.ResultsFile;

namespace ResultBridge.Core.Model.TestResults
{
    [XmlRoot(elementName: "categories")]
    public class Categories
    {
        [XmlElement(elementName: "category")]
        public List<category> Category { get; set; }
        [XmlAttribute("name")]
        public string Name { get; set; }
        public Categories()
        {
        }

        public Categories(List<category> category)
        {
            Category = category;
        }
    }
}