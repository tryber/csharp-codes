using Condo.Models;

namespace Condo.UseCases.Interfaces;

public interface ISendUserVerifiedMail
{
    void Execute(string email);
}