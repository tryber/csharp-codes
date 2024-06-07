namespace Condo.UseCases.Users.ChangePassword;
using Condo.UseCases.Interfaces;
using AutoMapper;
using Condo.DTOs;
using Condo.Models;
using Condo.Repository.Interfaces;
using static BCrypt.Net.BCrypt;
using Condo.Exceptions;

public class ChangePasswordUser : IChangePasswordUser
{
    protected readonly IUserRepository _repository;
    protected readonly IMapper _mapper;
    public ChangePasswordUser(IUserRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public void Execute(UserChangePasswordDTO userChangePasswordDTO)
    {
        User existingUser = _repository.GetById(userChangePasswordDTO.Id);
        if (existingUser == null) throw new BadRequestException("Something wrong");

        bool checkPassword = Verify(userChangePasswordDTO.OldPassword, existingUser.Password);
        if (!checkPassword) throw new BadRequestException("Wrong password");

        _repository.ChangePassword(existingUser.Id, HashPassword(userChangePasswordDTO.NewPassword));
    }
}



