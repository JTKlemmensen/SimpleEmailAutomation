using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEmailAutomation.Entities
{
    public class EmailSender
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public int FailedMailsSent { get; private set; }
        public int SuccessfulMailsSent { get; private set; }

        public void SendEmails(MessageTemplate template, DataList data)
        {
            FailedMailsSent = 0;
            SuccessfulMailsSent = 0;
            foreach(DataRow row in data.DataRows)
                using (MailMessage emailMessage = new MailMessage())
                {
                    try
                    {
                        emailMessage.From = new MailAddress(Settings.Username, GetValue(row, template.GetKeyword("<DisplayName>")));
                        emailMessage.To.Add(new MailAddress(GetValue(row, template.GetKeyword("<RecipientEmail>"))));
                        emailMessage.Subject = GetValue(row, template.GetKeyword("<Subject>"));
                        emailMessage.Body = template.Message(row);
                        emailMessage.Priority = MailPriority.Normal;
                        using (SmtpClient MailClient = new SmtpClient(Settings.Host, Settings.Port))
                        {
                            MailClient.EnableSsl = true;
                            MailClient.Credentials = new System.Net.NetworkCredential(Settings.Username, Settings.Password);
                            MailClient.Send(emailMessage);

                            SuccessfulMailsSent++;
                        }
                    }catch(Exception)
                    {
                        FailedMailsSent++;
                    }
                }
        }

        private string GetValue(DataRow row, KeyWord word)
        {
            return word.IsDynamic ? row.Value(word.Value) : word.Value;
        }
    }
}