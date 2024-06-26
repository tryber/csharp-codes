namespace Condo.UnitTest;
using Moq;
using Condo.UseCases.Interfaces;
using AutoMapper;
using Condo.DTOs;
using Condo.Models;
using Condo.Repository.Interfaces;
using Condo.Exceptions;
using Condo.UseCases.Users.CreateUser;

public class CreateUserTest
{
    private Mock<IUserRepository> _mockUserRepository;
    private Mock<ICreatePerson> _mockCreatePerson;
    private Mock<ISendUserCreatedMail> _mockSendUserCreatedMail;
    private Mock<IMapper> _mockAutoMapper;

    public CreateUserTest()
    {
        _mockUserRepository = new Mock<IUserRepository>();
        _mockCreatePerson = new Mock<ICreatePerson>();
        _mockSendUserCreatedMail = new Mock<ISendUserCreatedMail>();
        _mockAutoMapper = new Mock<IMapper>();
    }

    [Trait("Category", "Test Create User Use Case - Create new user")]
    [Theory(DisplayName = "Test Create User Use Case - Create new user")]
    [InlineData(2)]
    public void TestCreateUser(int UserIdParam)
    {
        User userMoq = new User {
            Id = UserIdParam,
            Name = "Rebeca",
            Email = "rebeca@email.com",
            Password = "password",
            Type = Types.UserType.Resident,
            PersonId = 2,
            VerificationCode = "xxxxxx"
        };

        UserCreatedResponseDTO userCreatedResponseDTO = new UserCreatedResponseDTO {
             Id = UserIdParam,
             Email = "rebeca@email.com",
             VerificationCode = "xxxxxx"
        };

        UserCreateDTO userCreateDTO = new UserCreateDTO {
            Name = "Rebeca",
            Email = "rebeca@email.com",
            Type = Types.UserType.Resident,
            Document = "444444444"
        };

        _mockUserRepository.Setup(r => r.GetByEmail(It.IsAny<string>()))
                           .Returns(default(User));
        _mockUserRepository.Setup(r => r.Add(It.IsAny<User>()))
                           .Returns(userMoq); 
        _mockCreatePerson.Setup(c => c.Execute(It.IsAny<Person>()))
                         .Returns(2);   
        _mockSendUserCreatedMail.Setup(s => s.Execute(It.IsAny<User>()))
                                .Verifiable();
        _mockAutoMapper.Setup(a => a.Map<User, UserCreatedResponseDTO>(It.IsAny<User>()))
                       .Returns(userCreatedResponseDTO);
        
        var createUserUseCase = new CreateUser(_mockUserRepository.Object,
                                               _mockSendUserCreatedMail.Object,
                                               _mockCreatePerson.Object,
                                               _mockAutoMapper.Object);
        var result = createUserUseCase.Execute(userCreateDTO);

        Assert.Equal(userCreatedResponseDTO, result);

        
    }

    [Trait("Category", "Test Create User Use Case - Existing user")]
    [Theory(DisplayName = "Test Create User Use Case - Existing user")]
    [InlineData(2)]
    public void TestCreateUserExistingUser(int UserIdParam)
    {
        User userMoq = new User {
            Id = UserIdParam,
            Name = "Rebeca",
            Email = "rebeca@email.com",
            Password = "password",
            Type = Types.UserType.Resident,
            PersonId = 2,
            VerificationCode = "xxxxxx"
        };

        UserCreateDTO userCreateDTO = new UserCreateDTO {
            Name = "Rebeca",
            Email = "rebeca@email.com",
            Type = Types.UserType.Resident,
            Document = "444444444"
        };

        _mockUserRepository.Setup(r => r.GetByEmail(It.IsAny<string>()))
                           .Returns(userMoq);

        var createUserUseCase = new CreateUser(_mockUserRepository.Object,
                                               _mockSendUserCreatedMail.Object,
                                               _mockCreatePerson.Object,
                                               _mockAutoMapper.Object);
        Action result = () => createUserUseCase.Execute(userCreateDTO);
        BadRequestException exception = Assert.Throws<BadRequestException>(result);
        Assert.Equal("User already exists", exception.Message);
    }

}