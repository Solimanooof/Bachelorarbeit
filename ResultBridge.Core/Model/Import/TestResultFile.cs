using System.Xml.Serialization;

namespace ResultBridge.Core.Model.Import
{

    public class TestResultFile
    {
        public string FilePath { get; }
        public string Name { get; }

        public TestResultFile(string filePath, string name)
        {
            FilePath = filePath;
            Name = name;
        }
    }
}