namespace ResultBridge.Core.Model.Windchill;

public class WindchillConfiguration
{
    public WindchillConfiguration(string hostName, int port)
    {
        HostName = hostName;
        Port = port;
    }

    public string HostName { get; }
    public int Port { get; }
}