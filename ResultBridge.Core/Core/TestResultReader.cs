using System;
using System.IO;
using System.Xml.Serialization;
using ResultBridge.Core.Model.Import;

namespace ResultBridge.Core.Core
{
    public class TestResultReader : ITestResultReader
    {
        public TestResultFile ImportTestResult(string path)
        {
            String Name = Path.GetFileName(path);
            TestResultFile testResultFile = new TestResultFile(path, Name);
            return testResultFile;
        }
    }
}