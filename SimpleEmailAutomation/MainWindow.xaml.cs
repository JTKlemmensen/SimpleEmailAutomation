using SimpleEmailAutomation.Entities;
using SimpleEmailAutomation.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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

namespace SimpleEmailAutomation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetView(new SettingsView());
        }

        private void GoToSendMails(object sender, RoutedEventArgs e)
        {
            SetView(new MailSenderView());
        }

        private void GoToSettings(object sender, RoutedEventArgs e)
        {
            SetView(new SettingsView());
        }

        public void SetView(UIElement element)
        {
            View.Children.Clear();
            View.Children.Add(element);
        }
    }
}