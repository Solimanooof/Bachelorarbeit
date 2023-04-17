using System.Collections.Generic;
using System.Diagnostics;
using ResultBridge.Core.Model;

namespace ResultBridge.Core.Core
{
    public class TestResultImporter : ITestResultImporter
    {
        public void SyncResultsToWindchill(IList<TestCase> testResults)
        {
            throw new System.NotImplementedException();
        }

        public void ConnectToWindChill(string path, string user, string password, string hostname, string port)
        {
            string cmdPath = @path + @"\im.exe";
            string cmdArgToLoginToWindChill = "connect" + " --user=" + user + " --password=" + password + " --port=" +
                                              port + " --hotname=" + hostname;
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = cmdPath;
            startInfo.Arguments = cmdArgToLoginToWindChill;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            Process process = new Process();
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
        }
    }


}