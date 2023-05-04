using System.Collections.Generic;
using NUnit.Framework;
using ResultBridge.Core.Core;
using ResultBridge.Core.Model.Import;
using ResultBridgeCore.Tests.Utils;
using System.IO;
using ResultBridge.Core.Core.TestImport.Impl;
using ResultBridge.Core.Model.TestResults;

namespace ResultBridgeCore.Tests.Core
{
    [TestFixture]
    public class TestResultProviderTests
    {
        [Test]
        public void CreateTestResultsFrom_ValidFile_ShouldReturnTestResult()
        {
            // Arrange
            string testResultsFilePath = FileHelper.ResolveFileFromTestResources("TestResults.xml");
            var provider = new TestResultProvider();
            TestResultFile testResultFile = new TestResultFile(Path.GetFullPath(testResultsFilePath), Path.GetFileName(testResultsFilePath));

            // Act
            TestSuite testSuite = provider.CreateTestResultsFrom(testResultFile);
            List<Result> result = testSuite.Results;



            // Assert
            Assert.IsNotNull(testSuite);
            Assert.IsInstanceOf<TestSuite>(testSuite);
            Assert.That(testSuite.Name, Is.EqualTo("_77OnlineshopFeature"));
            Assert.That(testSuite.Results, Is.Not.Empty);
        }
    }
}
