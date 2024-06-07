using Condo.DTOs;
using Condo.Models;
using Condo.UseCases.Interfaces;

namespace Condo.UseCases.MailService.SendUserCreatedMail;

public class SendUserCreatedMail : ISendUserCreatedMail
{
    protected readonly ISendEmail _sendEmail;
    public SendUserCreatedMail(ISendEmail sendEmail)
    {
        _sendEmail = sendEmail;
    }
    public void Execute(User user)
    {
        string messageText = "<h2>Condo Link</h2>";
        messageText += $"<p>Olá {user.Name}</p>";
        messageText += $"<p>A sua conta foi criada no Condo Link</p>";
        messageText += $"<p>Utilize o seu código de verificação para cadastrar a sua senha</p>";
        messageText += $"<div style='padding:10px;font-size:25px;color:#fff;background-color:#00c;width:180px;text-align:center;'>";
        messageText += user.VerificationCode;
        messageText += $"</div>";

        MailMessage mailMessage = new MailMessage("Condo Link - Usuário criado", messageText , user.Email!);
        _sendEmail.Execute(mailMessage);
    }
}