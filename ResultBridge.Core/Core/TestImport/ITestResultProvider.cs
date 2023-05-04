using System.Collections.Generic;
using ResultBridge.Core.Model.Import;
using ResultBridge.Core.Model.TestResults;

namespace ResultBridge.Core.Core.TestImport
{
    /// <summary>
    /// Transforms file content of TestResults.xml
    /// into model classes.
    /// </summary>
    public interface ITestResultProvider
    {
        TestSuite CreateTestResultsFrom(TestResultFile testResultFile);
    }
}