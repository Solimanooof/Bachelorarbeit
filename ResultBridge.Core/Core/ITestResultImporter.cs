using ResultBridge.Core.Model;
using System.Collections.Generic;

namespace ResultBridge.Core.Core
{
    public interface ITestResultImporter
    {
        public void SyncResultsToWindchill(IList<TestCase> testResults);
    }
}