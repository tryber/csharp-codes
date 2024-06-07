using Condo.Models;

namespace Condo.UseCases.Interfaces;

public interface ISendUserCreatedMail
{
    void Execute(User user);
}