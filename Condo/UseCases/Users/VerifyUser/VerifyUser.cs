namespace Condo.UseCases.Users.VerifyUser;
using Condo.UseCases.Interfaces;
using AutoMapper;
using Condo.DTOs;
using Condo.Models;
using Condo.Repository.Interfaces;
using static BCrypt.Net.BCrypt;
using Condo.Exceptions;

public class VerifyUser : IVerifyUser
{
    protected readonly IUserRepository _repository;
    protected readonly IMapper _mapper;
    public VerifyUser(IUserRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public void Execute(UserSetPasswordDTO userSetPasswordDTO)
    {
        User? existingUser = _repository.GetByEmail(userSetPasswordDTO.Email!);
        if (existingUser == null) throw new NotFoundException("User not found");

        if (existingUser.VerificationCode != userSetPasswordDTO.VerificationCode) throw new BadRequestException("Invalid Code");
        _repository.ChangePassword(existingUser.Id, HashPassword(userSetPasswordDTO.NewPassword));
    }
}