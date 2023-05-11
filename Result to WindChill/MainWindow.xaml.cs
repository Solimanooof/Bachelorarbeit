using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Extensions.DependencyInjection;
using ResultBridge.Core.Core.Windchill;


namespace Result_to_WindChill
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public IImportPage _importPage;
        public ILogInToWindChill _logInToWindChill;

        public MainWindow(ILogInToWindChill logInToWindChill, IImportPage import)
        {
            InitializeComponent();
            _logInToWindChill = logInToWindChill;
            _importPage = import;
            DataContext = this;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            string hostName = hostNameTextBox.Text;
            int port = int.Parse(portTextBox.Text);
            string userName = userNameTextBox.Text;
            string password = passwordTextBox.Password;


            _logInToWindChill.RunConnection(hostName, port, userName, password);



            _importPage.ShowThisPage();
            this.Close();


        }
    }
}
