using System;
using System.Diagnostics;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using ResultBridge.Core.Model;
using ResultBridge.Core.Model.Windchill;

namespace ResultBridge.Core.Core.Windchill;

public class WindchillConnector : IWindchillConnector
{
    private const string ImProgramName = "im.exe";
    private const string TmProgramName = "tm.exe";
    public event EventHandler? OnConnected;
    public event EventHandler? OnDisconnected;
    public event EventHandler<TestResultImportedEventArgs>? OnTestResultImported;
    public event EventHandler<CommandFailedEventArgs>? OnCommandFailed;

    private WindchillCommandBuilder windchillCommandBuilder;

    public string HostName { get; set; }
    public int Port { get; set; }
    public string UserName { get; }
    public string Password { get; }

    public WindchillConnector(WindchillConfiguration configuration, UserCredentials userCredentials)
    {
        HostName = configuration.HostName;
        Port = configuration.Port;
        UserName = userCredentials.UserName;
        Password = userCredentials.Password;
        windchillCommandBuilder = new WindchillCommandBuilder(UserName, Password, HostName, Port);
    }

    public bool IsConnected()
    {
        string isConnectedCommand = windchillCommandBuilder.BuildIsConnectedCommand();
        var processFinishedInfo = ExecuteImProcess(isConnectedCommand);
        return processFinishedInfo.StdOut.Contains("(default)");
    }


    public void Connect(string userName, string password)
    {
        string connectCommand = windchillCommandBuilder.BuildConnectCommand();
        var processFinishedInfo = ExecuteImProcess(connectCommand);
        if (processFinishedInfo.ExitCode == 0)
        {
            OnConnected?.Invoke(this, EventArgs.Empty);
        }
    }

    public void SetTestResultFor(string caseId, string result, string sessionId)
    {
        string setTestResultCommand = windchillCommandBuilder.BuildSetTestResultsCommand(caseId, result, sessionId);
        var processFinishedInfo = ExecuteTmProcess(setTestResultCommand);
        if (processFinishedInfo.ExitCode == 0)
        {
            OnTestResultImported?.Invoke(this, new TestResultImportedEventArgs(caseId, result));
        }
    }

    public void Disconnect()
    {
        string disconnectCommand = windchillCommandBuilder.BuildDisconnectCommand();
        var processFinishedInfo = ExecuteImProcess(disconnectCommand);
        if (processFinishedInfo.ExitCode == 0)
        {
            OnDisconnected?.Invoke(this, EventArgs.Empty);
        }
    }

    private ProcessFinishedInfo ExecuteImProcess(string arguments)
    {
        try
        {
            var finishedProcessInfo = StartProcess(ImProgramName, arguments);
            if (finishedProcessInfo.ExitCode != 0)
            {
                OnCommandFailed?.Invoke(this, new CommandFailedEventArgs(null, $"Expected exit code == 0 but was {finishedProcessInfo.ExitCode}"));
            }

            return finishedProcessInfo;
        }
        catch (Exception e)
        {
            OnCommandFailed?.Invoke(this, new CommandFailedEventArgs(e, $"Unexpected error during execution of IM command {arguments}"));
            return new ProcessFinishedInfo(1, "", "");
        }
    }


    private ProcessFinishedInfo ExecuteTmProcess(string arguments)
    {
        try
        {
            var finishedProcessInfo = StartProcess(TmProgramName, arguments);
            if (finishedProcessInfo.ExitCode != 0)
            {
                OnCommandFailed?.Invoke(this, new CommandFailedEventArgs(exception: null, message: $"Expected exit code == 0 but was {finishedProcessInfo.ExitCode}"));
            }

            return finishedProcessInfo;
        }
        catch (Exception e)
        {
            OnCommandFailed?.Invoke(this, new CommandFailedEventArgs(e, $"Unexpected error during execution of TM command {arguments}"));
            return new ProcessFinishedInfo(1, "", "");
        }
    }

    private ProcessFinishedInfo StartProcess(string executableNameOrPath, string arguments)
    {
        var process = new Process();
        var startInfo = new ProcessStartInfo();

        startInfo.FileName = executableNameOrPath;
        startInfo.Arguments = arguments;
        startInfo.UseShellExecute = false;
        startInfo.RedirectStandardOutput = true;
        startInfo.RedirectStandardError = true;
        process.StartInfo = startInfo;

        StringBuilder stdOutBuilder = new StringBuilder();
        StringBuilder stdErrBuilder = new StringBuilder();

        process.OutputDataReceived += (sender, args) => stdOutBuilder.Append(args.Data);
        process.ErrorDataReceived += (sender, args) => stdErrBuilder.Append(args.Data);

        process.Start();
        process.BeginOutputReadLine();
        process.BeginErrorReadLine();

        bool hasExisted = process.WaitForExit(TimeSpan.FromSeconds(15));
        if (!hasExisted)
        {
            process.Kill(true);
        }

        string stdOut = stdOutBuilder.ToString();
        string stdErr = stdErrBuilder.ToString();
        return new ProcessFinishedInfo(1, stdOut, stdErr);
    }
}

//sesseion 1380943
// testcase 1359213