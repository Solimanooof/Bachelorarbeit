using System.Collections.Generic;
using System.Xml.Serialization;

namespace ResultBridge.Core.Model.TestResults
{
    [XmlRoot(ElementName = "test-suite", Namespace = "", DataType = "object", IsNullable = false)]
    public class TestSuite
    {
        [XmlAttribute(AttributeName = "type")]
        public TestSuiteType Type { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlIgnore]
        public bool WasExecuted { get; set; }

        [XmlAttribute(AttributeName = "executed")]
        public string ExecutedSerialize
        {
            get => WasExecuted.ToString();
            set
            {
                if (value is "True")
                {
                    WasExecuted = true;
                }
                else if (value is "False")
                {
                    WasExecuted = false;
                }
            }
        }

        [XmlAttribute(AttributeName = "result")]
        public TestResult TestResult { get; set; }
        [XmlIgnore]
        public bool WasSuccessful { get; set; }

        [XmlAttribute("success")]
        public string SuccessfulSerialize
        {
            get => WasSuccessful.ToString();
            set
            {
                if (value is "True")
                {
                    WasSuccessful = true;
                }
                else if (value is "False")
                {
                    WasSuccessful = false;
                }
            }
        }

        [XmlElement("results")]
        public List<Result> Results { get; set; }

        public TestSuite()
        {
        }
    }
}