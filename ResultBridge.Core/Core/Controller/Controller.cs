using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Reflection.Metadata;
using ResultBridge.Core.Core.Windchill;
using ResultBridge.Core.Model;
using ResultBridge.Core.Model.Import;

namespace ResultBridge.Core.Core.Controller;

class Controller : IController
{

    /// <summary>
    /// class of WindChillConnector
    /// </summary>

    private string filePath;


    private WindchillConnector windchillConnector;
    public void ConnectToWindChill(string userName, string passWord, string hostName, int port)
    {
        windchillConnector = new WindchillConnector(hostName, port);
        windchillConnector.Connect(userName, passWord);
        windchillConnector.OnCommandFailed += (s, ev) => { };
        windchillConnector.OnConnected += (s, ev) => { };


    }
    public void DisconnectToWindChill()
    {
        windchillConnector.Disconnect();
    }

    public void SetResultsInWindChill(string testCaseID, string result, string sesseionID)
    {
        windchillConnector.SetTestResultFor(testCaseID, result, sesseionID);
    }

    // get the path from TestResultFile for Provider
    public TestResultFile GeTestResultFileForProvider(string filePath)
    {
        filePath = filePath.Trim();
        TestResultFile testResultFile = new TestResultFile(filePath);
        return testResultFile;
    }

    // deliver the testFileResult to Provider and get the testSuit

    public TestSuite GeTestSuite(TestResultFile testResultFile)
    {
        TestResultProvider testResultProvider = new TestResultProvider();
        return testResultProvider.CreateTestResultsFrom(GeTestResultFileForProvider(filePath));
    }

    public IList<TestCase> UseTestSuitFromProviderToGetTestCases()
    {
        TestSuite testSuite = GeTestSuite(GeTestResultFileForProvider(filePath));
        List<Result> results = testSuite.Results;
        IList<TestCase> testCases = new List<TestCase>();
        foreach (var result in results)
        {
            testCases = result.TestCases;
        }
        return testCases;
    }

    public void ImportResultsToWindChill()
    {
        TestResultImporter testResultImporter = new TestResultImporter();
        IList<TestCase> testCases = UseTestSuitFromProviderToGetTestCases();
        foreach (var testCase in testCases)
        {
            string testCasID = testCase.Categories.ToString();

            // there is no sesseionID in the xml 
            // here should be the last function 
        }

    }
}