using Condo.DTOs;
using Condo.Models;
using Condo.Repository.Interfaces;
using Condo.UseCases.Interfaces;

namespace Condo.UseCases.MailService.SendAccessCreatedMail;

public class SendAccessCreatedMail : ISendAccessCreatedMail
{
    private readonly ISendEmail _sendEmail;
     private readonly IUserRepository _userRepository;
    public SendAccessCreatedMail(ISendEmail sendEmail, IUserRepository userRepository)
    {
        _sendEmail = sendEmail;
        _userRepository = userRepository;
    }

    public void Execute(AccessResponseDTO accessResponseDTO)
    {
        User user = _userRepository.GetByUnity(accessResponseDTO.Unity!.Id);

        var messageText = "<h2>Condo Link</h2>";
        messageText += $"<p>Olá {user.Name}</p>";
        messageText += $"<p>Você liberou um acesso para uma pessoa visitante</p>";
        messageText += $"<p>Data: {accessResponseDTO.Date.ToString("dd/MM/yyyy")}</p>";
        messageText += $"<p>Unidade: {accessResponseDTO.Unity.Name}</p>";
        messageText += $"<p>Nome: {accessResponseDTO.Person.Name}</p>";
        messageText += $"<p>Documento: {accessResponseDTO.Person.Document}</p>";


        MailMessage mailMessage = new MailMessage("Condo Link - Acesso a visitante liberado", messageText, user.Email!);
        _sendEmail.Execute(mailMessage);
    }
}
