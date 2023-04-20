﻿using System;
using System.Diagnostics;

namespace ResultBridge.Core.Core.Windchill;

public class WindchillConnector : IWindchillConnector
{
    private const string ImProgramName = "im.exe";
    private const string TmProgramName = "tm.exe";
    public event EventHandler? OnConnected;
    public event EventHandler? OnDisconnected;
    public event EventHandler<TestResultImportedEventArgs>? OnTestResultImported;
    public event EventHandler<CommandFailedEventArgs>? OnCommandFailed;

    public string HostName { get; set; }
    public int Port { get; set; }

    public WindchillConnector(string hostName, int port)
    {
        HostName = hostName;
        Port = port;
    }

    private int ExecuteImProcess(string arguments)
    {
        return StartProcess(ImProgramName, arguments);
    }

    private int ExecuteTmProcess(string arguments)
    {
        return StartProcess(TmProgramName, arguments);
    }

    private int StartProcess(string executableNameOrPath, string arguments)
    {
        var process = new Process();
        var startInfo = new ProcessStartInfo();

        startInfo.FileName = executableNameOrPath;
        startInfo.Arguments = arguments;
        startInfo.UseShellExecute = false;
        startInfo.RedirectStandardOutput = true;
        process.StartInfo = startInfo;

        process.Start();
        process.WaitForExit();
        return process.ExitCode;
    }

    public void Connect(string userName, string password)
    {
        string connectCommand = BuildConnectCommand(userName, password);
        int processExitCode = ExecuteImProcess(connectCommand);
        if (processExitCode != 0)
        {
            OnCommandFailed?.Invoke(this, new CommandFailedEventArgs(null, $"Exit code of command '{connectCommand}' was ${processExitCode}"));
        }
        else
        {
            OnConnected?.Invoke(this, EventArgs.Empty);
        }
    }

    private string BuildConnectCommand(string userName, string password)
    {
        return $"connect --user={userName} --password={password} --port={Port} --hostname={HostName}";
    }

    public void SetTestResultFor(string caseId, string result, string sessionId)
    {
        string setTestResultCommand = BuildSetTestResultsCommand(caseId, result, sessionId);
        int exitCode = ExecuteTmProcess(setTestResultCommand);
        OnTestResultImported?.Invoke(this, new TestResultImportedEventArgs(caseId, result));
    }

    private static string BuildSetTestResultsCommand(string caseId, string result, string sessionId)
    {
        return $"editresult --verdict={result} --sessionID={sessionId} {caseId}";
    }

    public void Disconnect()
    {
        string disconnectCommand = BuildDisconnectCommand();
        ExecuteImProcess(disconnectCommand);
        OnDisconnected?.Invoke(this, EventArgs.Empty);
    }

    private string BuildDisconnectCommand()
    {
        return "disconnect";
    }
}