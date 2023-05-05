using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using ResultBridge.Core.Core.Windchill;
using ResultBridge.Core.Model;
using ResultBridge.Core.Model.ResultsFile;
using ResultBridge.Core.Model.TestResults;
using ResultBridge.Core.Model.Windchill;
using TestCase = ResultBridge.Core.Model.TestResults.TestCase;

namespace ResultBridge.Core.Core.TestImport.Impl
{
    public class TestResultImporter : ITestResultImporter
    {
        public WindchillConfiguration Configuration { get; }
        public UserCredentials Credentials { get; }
        public event EventHandler? TestResultImportStarted;
        public event EventHandler<TestResultImportFinishedEventArgs>? TestResultImportFinished;
        public event EventHandler? TestResultImportFailed;
        private int totalOfImportedTestCases = 0;
        private ITestResultProvider TestResultProvider;
        private WindchillConnector windchillConnector;

        public TestResultImporter(ITestResultProvider testResultProvider)
        {
            TestResultProvider = testResultProvider;
        }

        public TestResultImporter(WindchillConfiguration configuration, UserCredentials credentials)
        {
            Configuration = configuration;
            Credentials = credentials;
            windchillConnector = new WindchillConnector(configuration, credentials);
        }

        public TestResultImporter(WindchillConfiguration configuration, UserCredentials credentials, ITestResultProvider testResultProvider)
        {
            Configuration = configuration;
            Credentials = credentials;
            windchillConnector = new WindchillConnector(configuration, credentials);
        }
        public void SyncResultsToWindchill(IList<TestCase> testResults, string sessionID)
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


                string testCaseId = GetTestCaseIdFromCategories(testCase.Categories);
                windchillConnector.SetTestResultFor(testCaseId, testCase.Successful, sessionID);

                TestResultImportFinished?.Invoke(this, new TestResultImportFinishedEventArgs(0));
                totalOfImportedTestCases++;
            }
        }

        private static string GetTestCaseIdFromCategories(IList<Categories> categories)
        {
            string testCaseID = " ";

            foreach (var categeories in categories)
            {
                List<category> category = categeories.Category;
                var testCaseName = category.First(category => category.Name.StartsWith("TcID_"));
                testCaseID = testCaseName.Name.Replace("TcID_", "");

            }

            return testCaseID;
        }
    }
}