using System.Collections.Generic;
using System.Security.AccessControl;
using ResultBridge.Core.Core.TestImport;
using ResultBridge.Core.Core.TestImport.Impl;
using ResultBridge.Core.Core.Windchill;
using ResultBridge.Core.Model.Import;
using ResultBridge.Core.Model.TestResults;

namespace Result_to_WindChill;

public interface ISetResultToWindChillFromGUI
{
    public void ImpoertTestResultsToWindchillFromTestSuite(string sessionID, string filePath);
}
public class SetResultToWindChillFromGui : ISetResultToWindChillFromGUI
{


    public int totalOfImportedTestCases { get; set; }


    private ITestResultReader _testResultReader;
    private ITestResultProvider _testResultProvider;
    private ITestResultImporter _testResultImporter;



    public SetResultToWindChillFromGui(ITestResultProvider testResultProvider, ITestResultReader testResultReader, ITestResultImporter testResultImporter)
    {
        _testResultProvider = testResultProvider;
        _testResultReader = testResultReader;
        _testResultImporter = testResultImporter;
    }

    public TestSuite GeTestSuite(string filePath)
    {
        return _testResultProvider.CreateTestResultsFrom(_testResultReader.ImportTestResult(filePath));
    }

    public void ImpoertTestResultsToWindchillFromTestSuite(string sessionID, string filePath)
    {
        IList<TestCase> testCases = new List<TestCase>();
        IList<Result> testResults = GeTestSuite(filePath).Results;
        foreach (Result testResult in testResults)
        {
            testCases = testResult.TestCases;
        }


        _testResultImporter.SyncResultsToWindchill(testCases, sessionID);
    }




    public string TotalOfImportenTestCases()
    {
        _testResultImporter.TestResultImportFinished += TestResultImporter_TestResultImportFinished;
        return $"Total of imported testcases to WindChill are: {totalOfImportedTestCases}";
    }

    private void TestResultImporter_TestResultImportFinished(object? sender, ResultBridge.Core.Core.TestImport.TestResultImportFinishedEventArgs e)
    {
        totalOfImportedTestCases = e.TotalTestCasesImported;
    }
}