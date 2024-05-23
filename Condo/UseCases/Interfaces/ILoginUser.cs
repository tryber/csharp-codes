using Condo.DTOs;
namespace Condo.UseCases.Interfaces;

public interface ILoginUser
{
    LoginResponseDTO Execute(LoginRequestDTO loginRequestDTO);
}