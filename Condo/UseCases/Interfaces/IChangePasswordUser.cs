using Condo.DTOs;
namespace Condo.UseCases.Interfaces;

public interface IChangePasswordUser
{
    void Execute(UserChangePasswordDTO userChangePasswordDTO);
}