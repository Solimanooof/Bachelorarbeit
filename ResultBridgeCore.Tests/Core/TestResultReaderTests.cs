using NUnit.Framework;
using ResultBridge.Core.Core;
using ResultBridgeCore.Tests.Utils;

namespace ResultBridgeCore.Tests.Core
{
    [TestFixture]
    public class TestResultReaderTests
    {
        [Test]
        public void WhenImportingFileFromDisk_ShouldCreateIntermediateFileObject()
        {
            // Arrange
            string testResultsFilePath = FileHelper.ResolveFileFromTestResources("TestResults.xml");
            ITestResultReader testResultReader = new TestResultReader();

            // Act
            var importedTestResult = testResultReader.ImportTestResult(testResultsFilePath);

            // Assert
            Assert.That(importedTestResult.Name, Is.EqualTo("TestResults.xml"));
            Assert.That(importedTestResult.FilePath, Is.EqualTo(testResultsFilePath));
        }


    }
}
