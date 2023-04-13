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
            var name = Path.GetFileName(path);
            TestResultFile testResultFile = new TestResultFile(path, name);
            return testResultFile;
        }
    }
}