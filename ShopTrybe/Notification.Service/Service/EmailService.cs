namespace Notification.Service.Service;
using System.Text;
using System.Net;
using System.Net.Mail;
using Notification.Service.Models;

public class EmailService : MailMessage
{

    private static readonly string EMAIL_HOST = "smtp.gmail.com";
    private static readonly string EMAIL_FROM = "seu.email@gmail.com";
    private static readonly string EMAIL_PASSWORD = "xxxx xxxx xxxx xxxx";

    public static void Send(Message message)
    {
        try
        {
            using (var msgEmail = new MailMessage())
            {
                msgEmail.From = new MailAddress(EMAIL_FROM);
                msgEmail.To.Add(new MailAddress(message.MailTo));

                msgEmail.Subject = message.Title;
                msgEmail.Body = message.Text;
                msgEmail.BodyEncoding = Encoding.UTF8;
                msgEmail.IsBodyHtml = true;
                msgEmail.Priority = MailPriority.Normal;

                using (var smtpClient = new SmtpClient())
                {
                    smtpClient.Host = EMAIL_HOST;
                    smtpClient.Port = 587;
                    smtpClient.EnableSsl = true;
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.Credentials = new NetworkCredential(EMAIL_FROM, EMAIL_PASSWORD);
                    smtpClient.UseDefaultCredentials = false;

                    smtpClient.Send(msgEmail);
                }
            }
        }
        catch (SmtpFailedRecipientException ex)
        {
            Console.WriteLine("Message : {0} " + ex.Message);
            return;
        }
        catch (SmtpException ex)
        {
            Console.WriteLine("Message SMPT Fail : {0} " + ex.Message);
            return;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Message Exception : {0} " + ex.Message);
            return;
        }
    }
}