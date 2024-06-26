namespace Condo.UnitTest;
using Condo.DTOs;
using Condo.Repository.Interfaces;
using Condo.UseCases.Interfaces;
using Condo.Models;
using Condo.UseCases.People.CreatePerson;
using Moq;
using Condo.UseCases.Users.CreateUser;
using AutoMapper;
using Condo.Exceptions;
using Condo.UseCases.Users.Login;
using System.IdentityModel.Tokens.Jwt;

public class LoginTest
{
    private Mock<IUserRepository> _mockUserRepository;
    private Mock<IMapper> _mockAutoMapper;

    public LoginTest()
    {
        _mockUserRepository = new Mock<IUserRepository>();
        _mockAutoMapper = new Mock<IMapper>();
    }

    [Trait("Category", "Test Login Use Case")]
    [Theory(DisplayName = "Test Login Use Case")]
    [InlineData("rebeca@email.com", "SenhaForte123*")]
    public void Test_Login_Success(string email, string password)
    {
        User userMoq = new User
        {
            Id = 2,
            Name = "Rebeca",
            Email = email,
            Password = "$2y$04$0aSxdy0z75mb8t18jPfKxOtAbb3JApCEZpMTWO6nH6N0YvfnWWBri",
            Type = Types.UserType.Resident,
            PersonId = 2,
            VerificationCode = "xxxxxx"
        };

        LoginRequestDTO loginRequestDTO = new LoginRequestDTO
        {
            Email = email,
            Password = password
        };

        _mockUserRepository.Setup(r => r.GetByEmail(It.IsAny<string>()))
                           .Returns(userMoq);
        
        var loginUserUseCase = new LoginUser(_mockUserRepository.Object, _mockAutoMapper.Object);
        LoginResponseDTO result = loginUserUseCase.Execute(loginRequestDTO);

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.ReadToken(result.Token!) as JwtSecurityToken;
        var tokenEmail = token!.Claims.FirstOrDefault(claim => claim.Type == "email")!.Value;

        Assert.Contains(email, tokenEmail);

    }

     [Trait("Category", "Test Login Use Case - Wrong Password")]
    [Theory(DisplayName = "Test Login Use Case - Wrong Password")]
    [InlineData("rebeca@email.com", "SenhaForte123*a")]
    public void Test_Login_WrongPassword(string email, string password)
    {
        User userMoq = new User
        {
            Id = 2,
            Name = "Rebeca",
            Email = email,
            Password = "$2y$04$0aSxdy0z75mb8t18jPfKxOtAbb3JApCEZpMTWO6nH6N0YvfnWWBri",
            Type = Types.UserType.Resident,
            PersonId = 2,
            VerificationCode = "xxxxxx"
        };

        LoginRequestDTO loginRequestDTO = new LoginRequestDTO
        {
            Email = email,
            Password = password
        };

        _mockUserRepository.Setup(r => r.GetByEmail(It.IsAny<string>()))
                           .Returns(userMoq);
        
        var loginUserUseCase = new LoginUser(_mockUserRepository.Object, _mockAutoMapper.Object);
        Action result = () => loginUserUseCase.Execute(loginRequestDTO);

        BadRequestException exception = Assert.Throws<BadRequestException>(result);
        Assert.Equal("Invalid e-mail or password", exception.Message);
    }

    [Trait("Category", "Test Login Use Case - Not Found User")]
    [Theory(DisplayName = "Test Login Use Case - Not Found User")]
    [InlineData("rebeca@email.com", "SenhaForte123*a")]
    public void Test_Login_NotFoundUser(string email, string password)
    {
        LoginRequestDTO loginRequestDTO = new LoginRequestDTO
        {
            Email = email,
            Password = password
        };

        _mockUserRepository.Setup(r => r.GetByEmail(It.IsAny<string>()))
                           .Returns(default(User));
        
        var loginUserUseCase = new LoginUser(_mockUserRepository.Object, _mockAutoMapper.Object);
        Action result = () => loginUserUseCase.Execute(loginRequestDTO);

        BadRequestException exception = Assert.Throws<BadRequestException>(result);
        Assert.Equal("Invalid e-mail or password", exception.Message);
    }

}