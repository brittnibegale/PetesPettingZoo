using System;
using Newtonsoft.Json.Linq;
using System.Net.Mail;

namespace Mailjet.ConsoleApplication
{
    public class JetMail
    {

        public static void SendMail(string to, string subject, string body)
        {
            var mailMessage = new System.Net.Mail.MailMessage();
            mailMessage.To.Add(to);
            mailMessage.Subject = subject;
            mailMessage.Body = body;
            var smtpClient = new SmtpClient();
            smtpClient.Send(mailMessage);
        }
    }
}