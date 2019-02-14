using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace WebAppHttp.Model
{
    public class EmailSender
    {
        public static void Send(ref Email email)
        {
            email.Date = DateTime.Now;

            foreach (Recipient r in email.Recipients)
            {
                if (r.RecipientEmail.IndexOf('@') == -1)
                {
                    r.Result = "Failed";
                    r.FailedMessage = "Not an Email address";
                }
                else
                {
                    try
                    {
                        SendMail("login@mail.ru", "pass", r.RecipientEmail, email.Subject, email.Body); // my login and password was here
                        r.Result = "Ok";
                    }
                    catch (Exception e)
                    {
                        r.Result = "Failed";
                        r.FailedMessage = e.ToString();
                    }
                }
            }

        }

        private static void SendMail(string from, string password, string mailto, string subject, string body)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(from);
                mail.To.Add(new MailAddress(mailto));
                mail.Subject = subject;
                mail.Body = body;
                SmtpClient client = new SmtpClient();
                client.Host = "smtp." + from.Split('@')[1];
                client.Port = 587;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(from.Split('@')[0], password);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Send(mail);
                mail.Dispose();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
