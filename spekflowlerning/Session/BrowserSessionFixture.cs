using System.Xml;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using spekflowlerning.Model.Pages;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace spekflowlerning.Session;
[SetUpFixture]
[Binding]
public static class BrowserSessionFixture
{
    private static WebDriver _webDriver;

    public static WebDriver WebDriver
    {
        get => _webDriver;
        set => _webDriver = value;
    }
    
    [BeforeScenario]
    public static void SetUpDriver()
    {
        new DriverManager().SetUpDriver(new FirefoxConfig());
        var option = new FirefoxOptions
        {
            AcceptInsecureCertificates = true
        };
        WebDriver = new FirefoxDriver(option);
    }
    [TearDown]
    [AfterScenario]
    public static void TearDown()
    {
        // Erstellen einer XML-Datei mit Testergebnissen
        var doc = new XmlDocument();
        var xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
        var root = doc.DocumentElement;
        doc.InsertBefore(xmlDeclaration, root);

        var testResultsNode = doc.CreateElement("test-results");
        testResultsNode.SetAttribute("name", "MyTest");
        doc.AppendChild(testResultsNode);

        var testSuiteNode = doc.CreateElement("test-suite");
        testSuiteNode.SetAttribute("name", "MyTest.MyTestSuite");
        testSuiteNode.SetAttribute("type", "TestFixture");
        testSuiteNode.SetAttribute("executed", "True");
        testSuiteNode.SetAttribute("result", TestContext.CurrentContext.Result.Outcome.Status.ToString());
        testResultsNode.AppendChild(testSuiteNode);

        var testCaseNode = doc.CreateElement("test-case");
        testCaseNode.SetAttribute("name", TestContext.CurrentContext.Test.Name);
        testCaseNode.SetAttribute("executed", "True");
        testCaseNode.SetAttribute("result", TestContext.CurrentContext.Result.Outcome.Status.ToString());
        
        testSuiteNode.AppendChild(testCaseNode);

        doc.Save(@"C:\Workspace\spekflowlerning\TestResult.xml");


        WebDriver.Close();
        WebDriver.Quit();
    }
}