using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using ResultBridge.Core.Model;
using ResultBridge.Core.Model.Import;

namespace ResultBridge.Core.Core
{
    public class TestResultProvider : ITestResultProvider
    {
        public TestSuite CreateTestResultsFrom(TestResultFile testResultFile)
        {
            string xmlContent = File.ReadAllText(testResultFile.FilePath);

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xmlContent);

            XmlNodeList? nodes = xmlDocument.SelectNodes("*//test-suite[@type='TestFixture']");
            string testResultsXml = nodes?.Item(0).OuterXml;

            XmlSerializer serializer = new XmlSerializer(typeof(TestSuite));

            using (TextReader reader = new StringReader(testResultsXml))
            {
                TestSuite testSuites = (TestSuite)serializer.Deserialize(reader);
                return testSuites ?? new TestSuite();
            }

        }
    }
}