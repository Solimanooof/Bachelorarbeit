using System;
using System.Collections.Generic;
using ResultBridge.Core.Model.TestResults;

namespace ResultBridge.Core.Core.TestImport
{
    public interface ITestResultImporter
    {
        public event EventHandler TestResultImportStarted;
        public event EventHandler<TestResultImportFinishedEventArgs> TestResultImportFinished;
        public event EventHandler TestResultImportFailed;
        public void SyncResultsToWindchill(IList<TestCase> testResults, string sessionID);
    }

    public class TestResultImportFinishedEventArgs
    {
        public TestResultImportFinishedEventArgs(int totalTestCasesImported)
        {
            TotalTestCasesImported = totalTestCasesImported;
        }

        public int TotalTestCasesImported { get; }
    }
}