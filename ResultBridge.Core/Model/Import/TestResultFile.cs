namespace ResultBridge.Core.Model.Import
{

    public class TestResultFile
    {
        public string FilePath { get; }
        public string Name { get; }

        public TestResultFile()
        {
        }

        public TestResultFile(string filePath, string name)
        {
            FilePath = filePath;
            Name = name;
        }
    }
}