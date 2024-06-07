namespace Mail.API.UseCase;

using Mail.API.Models;
using System.Text;
using System.Net;
using System.Net.Mail;


public class SendMail : ISendMail
{
    public void Execute(Message message)
    {
        string EMAIL_HOST = Environment.GetEnvironmentVariable("EMAIL_HOST")!;
        string EMAIL_FROM = Environment.GetEnvironmentVariable("EMAIL_FROM")!;
        string EMAIL_PASSWORD = Environment.GetEnvironmentVariable("EMAIL_PASSWORD")!;

        try
        {
            using (var msgEmail = new MailMessage())
            {
                msgEmail.From = new MailAddress(EMAIL_FROM);
                msgEmail.To.Add(new MailAddress(message.MailTo!));

                msgEmail.Subject = message.Title;
                msgEmail.Body = message.Text;
                msgEmail.BodyEncoding = Encoding.UTF8;
                msgEmail.IsBodyHtml = true;
                msgEmail.Priority = MailPriority.Normal;

                using(var smtpClient = new SmtpClient())
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
        catch(SmtpFailedRecipientException ex)
        {
            Console.WriteLine("Error smtp recipient message:" +ex.Message.ToString());
            throw new Exception(ex.Message);
        }
        catch(SmtpException ex)
        {
            Console.WriteLine("Error smtp message:" +ex.Message.ToString());
            throw new Exception(ex.Message);
        }
        catch(Exception ex)
        {
            Console.WriteLine("Error message:" +ex.Message.ToString());
            throw new Exception(ex.Message);
        }
    }
}