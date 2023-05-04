using System.IO;
using ResultBridge.Core.Model.Import;

namespace ResultBridge.Core.Core.TestImport.Impl
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