using Condo.Types;

namespace Condo.DTOs;

public class UserCreateDTO
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public UserType Type { get; set; }
    public string? Document { get; set; }
}

public class UserCreatedResponseDTO
{
    public int Id { get; set; }
    public string? Email { get; set; }
    public string? VerificationCode { get; set; }
}

public class UserSetPasswordDTO
{
    public string? Email { get; set; }
    public string? VerificationCode { get; set; }
    public string? NewPassword { get; set; }
}

public class UserChangePasswordDTO
{
    public int Id { get; set; }
    public string? OldPassword { get; set; }
    public string? NewPassword { get; set; }
}

public class LoginRequestDTO
{
    public string? Email { get; set; }
    public string? Password { get; set; }
}

public class LoginResponseDTO
{
    public string? Token { get; set; }
}