using System.Xml.Serialization;

namespace ResultBridge.Core.Model.TestResults
{
    [XmlRoot(ElementName = "test-suite")]
    public enum TestSuiteType
    {
        [XmlEnum(Name = "TestSuite")]
        TestSuite,
        [XmlEnum(Name = "TestFixture")]
        TestFixture
    }
}