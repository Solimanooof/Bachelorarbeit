using System;

namespace ResultBridge.Core.Core.Windchill;

public interface IWindchillConnector
{
    public event EventHandler OnConnected;
    public event EventHandler OnDisconnected;
    public event EventHandler<TestResultImportedEventArgs> OnTestResultImported;
    public event EventHandler<CommandFailedEventArgs> OnCommandFailed;

    public string HostName { get; set; }
    public int Port { get; set; }

    bool IsConnected();
    void Connect(string userName, string password);
    void SetTestResultFor(string caseId, string result, string sessionId);
    void Disconnect();
}

public class CommandFailedEventArgs
{
    public CommandFailedEventArgs(Exception? exception, string? message)
    {
        Exception = exception;
        Message = message;
    }

    public Exception? Exception { get; }
    public string? Message { get; }
}

public class TestResultImportedEventArgs
{
    public TestResultImportedEventArgs(string caseId, string result)
    {
        TestResult = result;
        TestCaseId = caseId;
    }

    public string TestCaseId { get; }
    public string TestResult { get; }
}