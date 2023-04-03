using System.Collections.Generic;
using System.Xml.Serialization;

namespace ResultBridge.Core.Model
{
    public class TestSuite
    {
        [XmlAttribute(AttributeName = "type")]
        public TestSuiteType Type { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; private set; }

        [XmlAttribute(AttributeName = "executed")]
        public bool WasExecuted { get; private set; }

        [XmlAttribute(AttributeName = "result")]
        public Result Result { get; private set; }
        public bool WasSuccessful { get; private set; }
        public IList<TestCase> TestCases { get; private set; }
    }
}