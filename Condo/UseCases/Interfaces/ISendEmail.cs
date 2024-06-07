using Condo.DTOs;
namespace Condo.UseCases.Interfaces;
public interface ISendEmail
{
    void Execute(MailMessage mailMessage);
}