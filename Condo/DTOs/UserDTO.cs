using System.ComponentModel.DataAnnotations;
using Condo.Types;

namespace Condo.DTOs;

public class UserCreateDTO
{
    [Required(ErrorMessage = "Name is required")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "E-mail is required")]
    [EmailAddress(ErrorMessage = "Invalid e-mail address")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Type is required")]
    public UserType Type { get; set; }

    [Required(ErrorMessage = "Document is required")]
    [StringLength(14, MinimumLength = 9, ErrorMessage = "Document invalid")]
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
    [Required(ErrorMessage = "E-mail is required")]
    [EmailAddress(ErrorMessage = "Invalid e-mail address")]
    public string? Email { get; set; }
    [Required(ErrorMessage = "Verification code is required")]
    public string? VerificationCode { get; set; }

    [Required(ErrorMessage = "New password is required")]
    [RegularExpression(@"^(?=.*[0-9])(?=.*[A-Z])(?=.*[a-z]).*$", ErrorMessage = "Password must contain uppercase letter, lowercase letter and a number")]
    public string? NewPassword { get; set; }

    [Required(ErrorMessage = "Confirm password is required")]
    [Compare("NewPassword", ErrorMessage = "Passwords don't match")]
    public string? ConfirmPassword { get; set; }
}

public class UserChangePasswordDTO
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Old password is required")]
    public string? OldPassword { get; set; }
    [Required(ErrorMessage = "New password is required")]
    [RegularExpression(@"^(?=.*[0-9])(?=.*[A-Z])(?=.*[a-z]).*$", ErrorMessage = "Password must contain uppercase letter, lowercase letter and a number")]
    public string? NewPassword { get; set; }
}

public class LoginRequestDTO
{
    [Required(ErrorMessage = "E-mail is required")]
    [EmailAddress(ErrorMessage = "Invalid e-mail address")]
    public string? Email { get; set; }
    [Required(ErrorMessage = "Password is required")]
    public string? Password { get; set; }
}

public class LoginResponseDTO
{
    public string? Token { get; set; }
}