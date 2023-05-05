using System.Collections.Generic;
using System.Xml.Serialization;

namespace ResultBridge.Core.Model.TestResults
{
    [XmlRoot(elementName: "test-case")]
    public class TestCase
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlAttribute("description")]
        public string Description { get; set; }
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

        [XmlAttribute("result")]
        public TestResult TestResult { get; set; }

        [XmlIgnore]
        public string Successful { get; set; }
        [XmlAttribute("success")]
        public string ResultOfTestCase
        {
            get => Successful.ToString();
            set
            {
                if (value is "True")
                {
                    Successful = "Passed";
                }
                else if (value is "False")
                {
                    Successful = "Failed";
                }
            }
        }
        [XmlElement("categories")]
        public List<Categories> Categories { get; set; }

        public TestCase()
        {
        }
    }
}