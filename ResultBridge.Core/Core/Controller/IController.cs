using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResultBridge.Core.Core.Windchill;
using ResultBridge.Core.Model;
using ResultBridge.Core.Model.Import;

namespace ResultBridge.Core.Core.Controller
{
    public interface IController
    {

        //// Commands to WindChill
        //public void ConnectToWindChill(string userName, string passWord, string hostName, int port);
        //public void DisconnectToWindChill();
        //public void SetResultsInWindChill(string testCaseID, string result, string sesseionID);

        ////get the TestResultfile to use in Provider
        //public TestResultFile GeTestResultFileForProvider(string filePath);

        //// deliver the testFileResult to Provider and get the testSuit
        //public TestSuite GeTestSuite(TestResultFile testResultFile);
        void RunImport(string resultFileName, string sessionId);
    }
}
