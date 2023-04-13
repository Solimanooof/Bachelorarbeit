using System.Collections.Generic;
using System.Xml.Serialization;

namespace ResultBridge.Core.Model
{
    [XmlRoot(elementName: "test-case")]
    public class TestCase
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlAttribute("description")]
        public string Description { get; set; }
        [XmlAttribute("executed")]
        public bool WasExecuted { get; set; }
        [XmlAttribute("result")]
        public TestResult TestResult { get; set; }
        [XmlAttribute("success")]
        public bool WasSuccessful { get; set; }
        [XmlElement("categories")]
        public List<Category> Categories { get; set; }

        public TestCase()
        {
        }
    }
}