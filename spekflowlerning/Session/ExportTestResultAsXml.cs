using System.IO;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestPlatform.TestExecutor;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Logging;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;

namespace spekflowlerning.Session
{
    public  class ExportTestResultAsXml
    {
        private readonly ITestResult _result;

        public ExportTestResultAsXml(ITestResult result)
        {
            _result=result;
        }

        public void Export(string filePath)
        {
            

        }
    }
}
