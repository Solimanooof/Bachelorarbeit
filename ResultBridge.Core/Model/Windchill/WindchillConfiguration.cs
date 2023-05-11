namespace ResultBridge.Core.Model.Windchill;

public interface IWindchillConfiguration
{
    public string HostName { get; set; }
    public int Port { get; set; }
}

public class WindchillConfiguration : IWindchillConfiguration
{
    public WindchillConfiguration(string hostName, int port)
    {
        HostName = hostName;
        Port = port;
    }

    public string HostName { get; set; }
    public int Port { get; set; }
}