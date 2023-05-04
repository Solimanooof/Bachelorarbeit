using System.IO;
using System.Xml;
using System.Xml.Serialization;
using ResultBridge.Core.Model.Import;
using ResultBridge.Core.Model.TestResults;

namespace ResultBridge.Core.Core.TestImport.Impl
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
                //OnTestSuitDeserializedFromXmlFile(testSuites);
                return testSuites ?? new TestSuite();
            }

        }


    }


}