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
    /// Interaction logic for MailSenderView.xaml
    /// </summary>
    public partial class MailSenderView : UserControl
    {
        private string file;
        public MailSenderView()
        {

            InitializeComponent();

            this.Keywords.AddKeyword("<RecipientEmail>", false, false);
            this.Keywords.AddKeyword("<DisplayName>", false, false);
            this.Keywords.AddKeyword("<Subject>", false, false);
        }

        private void SendEmails(object sender, RoutedEventArgs e)
        {
            MessageTemplate messageTemplate = new MessageTemplate();

            DataList list;

            try
            {
                list = new DataList(file);
            }
            catch (Exception)
            {
                MessageBox.Show("Something was wrong with the chosen file",
                                "Confirmation",
                                MessageBoxButton.OK,
                                MessageBoxImage.Question);
                return;
            }

            messageTemplate.Template = this.Message.Text;

            foreach (UIElement element in this.Keywords.Keywords.Children)
                if (element is FieldLine)
                {
                    FieldLine line = (element as FieldLine);
                    messageTemplate.SetKeywod(line.Identifier.Text, line.Value.Text, line.Dynamic.IsChecked ?? false);
                }

            EmailSender emailSender = new EmailSender();
            emailSender.SendEmails(messageTemplate, list);

            int totalMails = emailSender.FailedMailsSent + emailSender.SuccessfulMailsSent;

            string message;
            if (emailSender.FailedMailsSent > 0)
                message = "There were " + emailSender.FailedMailsSent + "/" + totalMails + " emails that were not sent ";
            else
                message = "All " + totalMails + " were sent successfully!";

            MessageBox.Show(message,
                            "Confirmation",
                            MessageBoxButton.OK,
                            MessageBoxImage.Question);
        }

        private void OnUploadFile(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                this.FileName.Content = filename;
                this.FileName.ToolTip = filename;
                file = filename;
            }
            else
            {
                this.FileName.Content = "No file chosen";
                this.FileName.ToolTip = "";
                file = "";
            }
        }
    }
}
