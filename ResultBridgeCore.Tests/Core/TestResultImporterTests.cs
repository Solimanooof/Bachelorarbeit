using NUnit.Framework;
using ResultBridge.Core.Core;
using ResultBridge.Core.Model.Import;
using System;
using System.Collections.Generic;
using System.IO;
using ResultBridge.Core.Core.TestImport;
using ResultBridge.Core.Core.TestImport.Impl;
using ResultBridgeCore.Tests.Utils;
using ResultBridge.Core.Model.TestResults;
using ResultBridge.Core.Core.Windchill;
using ResultBridge.Core.Model.Windchill;
using ResultBridge.Core.Model;

namespace ResultBridgeCore.Tests.Core
{
    [TestFixture]
    public class TestResultImporterTests
    {
        [Test]
        public void SyncResultsToWindchill_StateUnderTest_ExpectedBehavior()
        {
            var windchillConfiguration = new WindchillConfiguration("emea-integrity.karlstorz.com", 7001);
            var userCredentials = new UserCredentials("soabdelwah", "12363");
            var windchillConnector = new WindchillConnector(windchillConfiguration, userCredentials);

            // Arrange
            string testResultsFilePath = FileHelper.ResolveFileFromTestResources("TestResults.xml");
            var provider = new TestResultProvider();
            TestResultFile testResultFile = new TestResultFile(Path.GetFullPath(testResultsFilePath), Path.GetFileName(testResultsFilePath));

            ITestResultProvider testResultProvider = new TestResultProvider();

            var testResultImporter = new TestResultImporter(windchillConfiguration, userCredentials, testResultProvider);

            TestSuite testResultsSuiteFromProvider = testResultProvider.CreateTestResultsFrom(testResultFile);
            List<Result> results = testResultsSuiteFromProvider.Results;
            IList<TestCase> testCases = new List<TestCase>();
            foreach (var result in results)
            {
                testCases = result.TestCases;
            }

            bool importStartedevent = false;
            testResultImporter.TestResultImportStarted += (sender, args) => importStartedevent = true;

            // Act
            testResultImporter.SyncResultsToWindchill(testCases, "1380943");

            // Assert
            Assert.IsTrue(importStartedevent);
            Assert.That(testCases.Count > 1);
        }
    }
}
