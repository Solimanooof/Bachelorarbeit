using NUnit.Framework;
using ResultBridge.Core.Core;
using ResultBridgeCore.Tests.Utils;
using ResultBridge.Core.Model.Import;
using System;
using System.IO;
using ResultBridge.Core.Model;

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
            TestResults testResults = provider.CreateTestResultsFrom(testResultFile);

            // Assert
            Assert.IsNotNull(testResults);
            Assert.IsInstanceOf<TestResults>(testResults);
        }
    }
}
