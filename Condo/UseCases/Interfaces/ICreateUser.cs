using Condo.DTOs;
using Condo.Models;
namespace Condo.UseCases.Interfaces;
public interface ICreateUser
{
   UserCreatedResponseDTO Execute(UserCreateDTO userCreateDTO);
}