using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ResultBridge.Core.Core.Windchill;
using ResultBridge.Core.Model;
using ResultBridge.Core.Model.Windchill;

namespace Result_to_WindChill
{
    public interface ILogInToWindChill
    {
        public void RunConnection(string hostName, int port, string userName, string password);
    }
    public class LogInToWindChill : ILogInToWindChill
    {

        private IWindchillConfiguration _windchillConfiguration;
        private IWindchillCommandBuilder _windchillCommandBuilder;
        private IWindchillConnector _windchillConnector;
        private IUserCredentials _credentials;

        public LogInToWindChill(IWindchillConfiguration windchillConfiguration, IWindchillCommandBuilder windchillCommandBuilder, IWindchillConnector windchillConnector, IUserCredentials credentials)
        {
            _windchillConfiguration = windchillConfiguration;
            _windchillCommandBuilder = windchillCommandBuilder;
            _windchillConnector = windchillConnector;
            _credentials = credentials;
        }


        public void RunConnection(string hostName, int port, string userName, string password)
        {
            _windchillConfiguration.HostName = hostName;
            _windchillConfiguration.Port = port;

            _windchillCommandBuilder.HostName = hostName;
            _windchillCommandBuilder.Port = port;
            _windchillCommandBuilder.UserName = userName;
            _windchillCommandBuilder.Password = password;
            _credentials.Password = password;
            _credentials.UserName = userName;

            connectToWindChill();
        }

        public void connectToWindChill()
        {
            _windchillConnector = new WindchillConnector(_windchillConfiguration, _credentials);
            _windchillConnector.Connect();

        }

    }
}
