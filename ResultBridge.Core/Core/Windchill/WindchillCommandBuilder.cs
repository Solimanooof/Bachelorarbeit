namespace ResultBridge.Core.Core.Windchill;

public interface IWindchillCommandBuilder
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string HostName { get; set; }
    public int Port { get; set; }
}
public class WindchillCommandBuilder : IWindchillCommandBuilder
{
    public WindchillCommandBuilder(string userName, string password, string hostName, int port)
    {
        UserName = userName;
        Password = password;
        HostName = hostName;
        Port = port;
    }

    public string UserName { get; set; }
    public string Password { get; set; }
    public string HostName { get; set; }
    public int Port { get; set; }

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