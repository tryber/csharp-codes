namespace Condo.UseCases.Users.CreateUser;

using Condo.UseCases.Interfaces;
using AutoMapper;
using Condo.DTOs;
using Condo.Models;
using Condo.Repository.Interfaces;
using System.Text;
using static BCrypt.Net.BCrypt;
using Condo.Exceptions;

public class CreateUser : ICreateUser
{
    protected readonly IUserRepository _userRepository;
    protected readonly ICreatePerson _createPerson;
    protected readonly ISendUserCreatedMail _sendUserCreatedMail;
    protected readonly IMapper _mapper;
     public CreateUser(IUserRepository UserRepository, ISendUserCreatedMail sendUserCreatedMail, ICreatePerson createPerson, IMapper mapper)
    {
        _userRepository = UserRepository;
        _createPerson = createPerson;
        _sendUserCreatedMail = sendUserCreatedMail;
        _mapper = mapper;
    }
    public UserCreatedResponseDTO Execute(UserCreateDTO userCreateDTO)
    {
        User? existingUser = _userRepository.GetByEmail(userCreateDTO.Email!);
        if (existingUser != null) throw new BadRequestException("User already exists");
        
        Person newPerson = new Person {
            Name = userCreateDTO.Name,
            Document = userCreateDTO.Document
        };
        int myPersonId = _createPerson.Execute(newPerson);

        User newUser = new User
        {
            Name = userCreateDTO.Name,
            Email = userCreateDTO.Email,
            Type = userCreateDTO.Type,
            PersonId = myPersonId,
            Password = HashPassword(GenerateRandom(6)),
            VerificationCode = GenerateRandom(10)
        };

        _sendUserCreatedMail.Execute(newUser);
        User createdUser = _userRepository.Add(newUser);
        return _mapper.Map<User, UserCreatedResponseDTO>(createdUser);
    }

    private string GenerateRandom(int size)
    {
        var builder = new StringBuilder(size);
        char letter = 'a';
        int letterOff = 26;
        Random random = new Random();

        for (int i = 0; i < size; i++) {
            var newLetter = (char)random.Next(letter, letter + letterOff);
            builder.Append(newLetter);
        }
        return builder.ToString();
    }
    
}