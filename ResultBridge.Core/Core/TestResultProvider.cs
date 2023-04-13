using System;
using System.IO;
using System.Xml.Serialization;
using ResultBridge.Core.Model;
using ResultBridge.Core.Model.Import;

namespace ResultBridge.Core.Core
{
    public class TestResultProvider : ITestResultProvider
    {
        public TestResults CreateTestResultsFrom(TestResultFile testResultFile)
        {
            string xmlContent = File.ReadAllText(testResultFile.FilePath + @"\" + testResultFile.Name);

            XmlSerializer serializer = new XmlSerializer(typeof(TestResultFile));

            using (TextReader reader = new StringReader(xmlContent))
            {
                TestResults testResults = new TestResults();
                testResults = (TestResults)serializer.Deserialize(reader);
                return testResults ?? new TestResults();
            }

        }
    }
}