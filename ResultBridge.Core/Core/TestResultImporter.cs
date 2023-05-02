using System;
using ResultBridge.Core.Model;
using System.Collections.Generic;
using ResultBridge.Core.Model.Import;
using System.Diagnostics;

namespace ResultBridge.Core.Core
{
    public class TestResultImporter : ITestResultImporter
    {
        public event EventHandler? TestResultImportStarted;
        public event EventHandler<TestResultImportFinishedEventArgs>? TestResultImportFinished;
        public event EventHandler? TestResultImportFailed;

        private ITestResultProvider TestResultProvider;

        public TestResultImporter(ITestResultProvider testResultProvider)
        {
            TestResultProvider = testResultProvider;
        }

        public TestResultImporter()
        {

        }
        public void SyncResultsToWindchill(IList<TestCase> testResults)
        {
            // Todo
            // 1. Alle IDs aus der Liste von Ergebnisse auslesen
            // 2. Für jedes Element muss ein Testergebnisse nach WindchillConnector übertragen werden
            //    2.1 Anhand des Testergebnis muss entschieden werden, welches Testergebnis in
            //        WindchillConnector gesetzt werden muss (unterschiedliche Werte müssen via `im.exe`
            //        gesetzt werden)
            //    2.2 Prüfen, ob es beim Import einen Fehler gab
            // 3. Auswerten, ob Import erfolgreich oder nicht

            foreach (var testCase in testResults)
            {
                TestResultImportStarted?.Invoke(this, EventArgs.Empty);
                string name = testCase.Name;
                string description = testCase.Description;
                bool wasExecuted = testCase.WasExecuted;
                TestResult testResult = testCase.TestResult;
                bool wasSuccessful = testCase.WasSuccessful;

                foreach (var category in testCase.Categories)
                {
                    string testCaseID = category.Name;
                }
                TestResultImportFinished?.Invoke(this, new TestResultImportFinishedEventArgs(0));
            }
        }
    }
}