using ResultBridge.Core.Model.Import;

namespace ResultBridge.Core.Core.TestImport
{
    /// <summary>
    /// Reads in content of TestResult.xml and provides
    /// intermediate file object to access file.
    /// </summary>
    public interface ITestResultReader
    {
        TestResultFile ImportTestResult(string path);
    }
}