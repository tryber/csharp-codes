using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Condo.DTOs;
using Condo.Models;
using Condo.Repository.Interfaces;
using Condo.UseCases.Interfaces;
using Microsoft.IdentityModel.Tokens;
using static BCrypt.Net.BCrypt;


namespace Condo.UseCases.Users.Login;

public class LoginUser : ILoginUser
{
    protected readonly IUserRepository _repository;
    protected readonly IMapper _mapper;
    public LoginUser(IUserRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public LoginResponseDTO Execute(LoginRequestDTO loginRequestDTO)
    {
        User? existingUser = _repository.GetByEmail(loginRequestDTO.Email!);
        if (existingUser == null) throw new Exception("Invalid e-mail or password");

        bool checkPassword = Verify(loginRequestDTO.Password, existingUser.Password);
        if (!checkPassword) throw new Exception("Invalid e-mail or password");

        return new LoginResponseDTO {
            Token = GenerateToken(existingUser)
        };
    }

    private string GenerateToken(User user)
    {

        string Secret = "4d82a63bbdc67c1e4784ed6587f3730c";
        int ExpiresDay = 1;

        var claimsIdentity = new ClaimsIdentity();
        claimsIdentity.AddClaim(new Claim(ClaimTypes.Email, user.Email!));
        claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, user.Type.ToString()!));

        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = claimsIdentity,
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Secret)),
                SecurityAlgorithms.HmacSha256Signature
            ),
            Expires = DateTime.Now.AddDays(ExpiresDay)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}