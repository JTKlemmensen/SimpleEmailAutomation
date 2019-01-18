using SimpleEmailAutomation.Entities;
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

namespace SimpleEmailAutomation.Views
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class SettingsView : UserControl
    {
        public SettingsView()
        {
            InitializeComponent();
        }

        private void OnSave(object sender, RoutedEventArgs e)
        {
            if(int.TryParse(Port.Text,out int port))
            {
                Settings.Port = port;
                Settings.Username = Username.Text;
                Settings.Password = Password.Password;
                MessageBox.Show("Settings have been saved",
                                "Confirmation",
                                MessageBoxButton.OK,
                                MessageBoxImage.Question);
            }
            else
            {
                MessageBox.Show("The port is not valid",
                "Confirmation",
                MessageBoxButton.OK,
                MessageBoxImage.Question);
            }
        }
    }
}