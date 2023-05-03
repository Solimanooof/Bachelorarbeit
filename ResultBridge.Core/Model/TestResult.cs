using System.Xml.Serialization;

namespace ResultBridge.Core.Model
{
    public enum TestResult
    {
        [XmlEnum(Name = "Failure")]
        Failure,
        [XmlEnum(Name = "Success")]
        Success,
        [XmlEnum(Name = "Error")]
        Error

    }
}