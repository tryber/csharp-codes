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
    protected readonly ISendUserVerifiedMail _sendUserVerifiedMail;
    protected readonly IMapper _mapper;
    public VerifyUser(IUserRepository repository, ISendUserVerifiedMail sendUserVerifiedMail, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
        _sendUserVerifiedMail = sendUserVerifiedMail;
    }
    public void Execute(UserSetPasswordDTO userSetPasswordDTO)
    {
        User? existingUser = _repository.GetByEmail(userSetPasswordDTO.Email!);
        if (existingUser == null) throw new NotFoundException("User not found");

        if (existingUser.VerificationCode != userSetPasswordDTO.VerificationCode) throw new BadRequestException("Invalid Code");
        _repository.ChangePassword(existingUser.Id, HashPassword(userSetPasswordDTO.NewPassword));
        _sendUserVerifiedMail.Execute(userSetPasswordDTO.Email!);
    }
}