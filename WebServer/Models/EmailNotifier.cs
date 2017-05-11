using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace EmailNotifier
{
    public interface IEmailNotifier
    {
        void Send(string Caption, string Message, string To);
    }
    public class MailRuNotifier : IEmailNotifier
    {
        SmtpClient client = new SmtpClient();
        MailMessage mail = new MailMessage();
        public MailRuNotifier(string host, string password)
        {
            mail.From = new MailAddress(host);
            client.Host = "smtp.mail.ru";
            client.Port = 25;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential(host, password);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
        }
        public void Send(string Caption, string Message, string To)
        {
            mail.To.Add(new MailAddress(To));
            mail.Subject = Caption;
            mail.Body = Message;
            client.Send(mail);
        }
    }
}
