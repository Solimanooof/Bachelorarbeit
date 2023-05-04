namespace ResultBridge.Core.Core.Windchill;

public class WindchillCommandBuilder
{
    public WindchillCommandBuilder(string userName, string password, string hostName, int port)
    {
        UserName = userName;
        Password = password;
        HostName = hostName;
        Port = port;
    }

    public string UserName { get; }
    public string Password { get; }
    public string HostName { get; }
    public int Port { get; }

    public string BuildConnectCommand()
    {
        return $"connect --user={UserName} --password={Password} --port={Port} --hostname={HostName}";
    }

    public string BuildSetTestResultsCommand(string caseId, string result, string sessionId)
    {
        return $"editresult --verdict={result} --sessionID={sessionId} {caseId}";
    }
    public string BuildDisconnectCommand()
    {
        return "disconnect --no confirm";
    }

    public string BuildIsConnectedCommand()
    {
        return "servers";
    }
}