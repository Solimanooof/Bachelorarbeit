using System.Xml.Serialization;

namespace ResultBridge.Core.Model
{
    public enum Result
    {
        [XmlEnum(Name = "Failure")]
        Failure,
        [XmlEnum(Name = "Success")]
        Success
    }
}