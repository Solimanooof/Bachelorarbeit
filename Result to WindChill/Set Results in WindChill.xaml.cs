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
using System.Windows.Shapes;
using Microsoft.Win32;
using ResultBridge.Core.Core.TestImport;
using ResultBridge.Core.Core.Windchill;

namespace Result_to_WindChill
{
    /// <summary>
    /// Interaction logic for ImportPage.xaml
    /// </summary>
    public interface IImportPage
    {
        public void ShowThisPage();

    }


    public partial class ImportPage : Window, IImportPage
    {
        private ISetResultToWindChillFromGUI _setResultToWindChillFromGui;
        public ImportPage(ISetResultToWindChillFromGUI setResultToWindChillFromGui)
        {
            _setResultToWindChillFromGui = setResultToWindChillFromGui;
            InitializeComponent();

        }



        private void btnSetResultsInWindChill_Click(object sender, RoutedEventArgs e)
        {

            string filePath = xmlFilePathTextBox.Text;
            string sessionId = sessionIdTextBox.Text;



            _setResultToWindChillFromGui.ImpoertTestResultsToWindchillFromTestSuite(sessionId, filePath);

            reportesTextBlock.Text = "111";
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();

        }

        private void btnUploadFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = ".xml";


            bool? result = openFileDialog.ShowDialog();


            if (result == true)
            {
                xmlFilePathTextBox.Text = openFileDialog.FileName;

            }
        }

        public void ShowThisPage()
        {
            this.Show();
        }
    }
}
