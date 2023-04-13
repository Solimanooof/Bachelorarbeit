using System.Collections.Generic;
using System.Xml.Serialization;

namespace ResultBridge.Core.Model
{
    [XmlRoot("test-results")]
    public class TestResults
    {
        [XmlArray("TestSuites")]
        [XmlArrayItem("TestSuite")]
        public IList<TestSuite> TestSuites { get; set; }
    }
}