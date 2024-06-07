using Condo.DTOs;
namespace Condo.UseCases.Interfaces;

public interface IVerifyUser
{
    void Execute(UserSetPasswordDTO userSetPasswordDTO);
}