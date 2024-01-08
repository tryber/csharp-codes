namespace Auth.API.Repository;
using Auth.API.DTO;

public interface IUserRepository
{
    UserResponseDTO Create(UserInsertDTO user);
    UserResponseDTO Login(LoginDTO user);
}