using System.Collections.Generic;
using System.Xml.Serialization;

namespace ResultBridge.Core.Model
{
    [XmlRoot(elementName: "test-case")]
    public class TestCase
    {
        [XmlAttribute("name")]
        public string Name { get; private set; }
        [XmlAttribute("description")]
        public string Description { get; private set; }
        [XmlAttribute("executed")]
        public bool WasExecuted { get; private set; }
        [XmlAttribute("result")]
        public Result Result { get; private set; }
        [XmlAttribute("success")]
        public bool WasSuccessful { get; private set; }
        [XmlElement("categories")]
        public IList<Category> Categories { get; private set; }
    }
}