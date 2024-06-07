namespace Condo.Repository.Interfaces;
using Condo.Models;
using Condo.Types;

public interface IUserRepository
{
    User Add(User user);
    User GetById(int Id);
    User? GetByEmail(string email);
    void ChangePassword(int Id, string NewPassword);
    User GetByUnity(int UnityId);
}