using System.Collections.Generic;
using System.Xml.Serialization;

namespace ResultBridge.Core.Model.TestResults;

public class Result
{
    [XmlElement(ElementName = "test-case")]
    public List<TestCase> TestCases { get; set; }

    public Result()
    {
    }

    public Result(List<TestCase> testCases)
    {
        TestCases = testCases;
    }
}