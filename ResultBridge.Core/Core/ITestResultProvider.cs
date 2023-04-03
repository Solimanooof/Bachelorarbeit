using ResultBridge.Core.Model;
using ResultBridge.Core.Model.Import;

namespace ResultBridge.Core.Core
{
    /// <summary>
    /// Transforms file content of TestResults.xml
    /// into model classes.
    /// </summary>
    public interface ITestResultProvider
    {
        TestResults CreateTestResultsFrom(TestResultFile testResultFile);
    }
}