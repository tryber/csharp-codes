using Condo.DTOs;
using Condo.Models;
using Condo.UseCases.Interfaces;

namespace Condo.UseCases.MailService.SendUserVerifiedMail;

public class SendUserVerifiedMail : ISendUserVerifiedMail
{
    protected readonly ISendEmail _sendEmail;
    public SendUserVerifiedMail(ISendEmail sendEmail)
    {
        _sendEmail = sendEmail;
    }

    public void Execute(string email)
    {
        string messageText = "<h2>Condo Link</h2>";
        messageText += $"<p>A sua conta foi verificada no Condo Link</p>";
        MailMessage mailMessage = new MailMessage("Condo Link - Usuário verificado", messageText , email!);
        _sendEmail.Execute(mailMessage);
    }
}