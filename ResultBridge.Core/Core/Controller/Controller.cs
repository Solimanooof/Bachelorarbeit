using ResultBridge.Core.Core.TestImport.Impl;
using ResultBridge.Core.Core.Windchill;
using ResultBridge.Core.Model;
using ResultBridge.Core.Model.Import;
using ResultBridge.Core.Model.TestResults;
using ResultBridge.Core.Model.Windchill;
using System.Collections.Generic;

namespace ResultBridge.Core.Core.Controller;

public class Controller : IController
{
    public UserCredentials Credentials { get; }
    public WindchillConfiguration Configuration { get; }


    private readonly WindchillConnector windchillConnector;
    private readonly TestResultImporter resultImporter;
    private readonly TestResultProvider resultProvider;
    private readonly TestResultReader testResultReader;

    public Controller(WindchillConfiguration configuration, UserCredentials userCredentials)
    {
        Configuration = configuration;
        Credentials = userCredentials;
        windchillConnector = new WindchillConnector(Configuration, Credentials);
        resultProvider = new TestResultProvider();
        resultImporter = new TestResultImporter(resultProvider);
        testResultReader = new TestResultReader();
    }

    public void RunImport(string fileName, string sessionId)
    {
        TestResultFile testResultFile = testResultReader.ImportTestResult(fileName);
        TestSuite testSuite = resultProvider.CreateTestResultsFrom(testResultFile);
        IList<Result> testSuites = testSuite.Results;

        if (!windchillConnector.IsConnected())
        {
            windchillConnector.Connect();
        }

        foreach (Result result in testSuites)
        {
            resultImporter.SyncResultsToWindchill(result.TestCases, sessionId);
        }

    }
}