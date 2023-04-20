using System;
using ResultBridge.Core.Model;
using System.Collections.Generic;

namespace ResultBridge.Core.Core
{
    public interface ITestResultImporter
    {
        public event EventHandler TestResultImportStarted;
        public event EventHandler<TestResultImportFinishedEventArgs> TestResultImportFinished;
        public event EventHandler TestResultImportFailed;
        public void SyncResultsToWindchill(IList<TestCase> testResults);
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