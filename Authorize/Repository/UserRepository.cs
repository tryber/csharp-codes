using Authorize.Models;

namespace Authorize.Repository;

public class UserRepository
{
    private List<User> _users = new List<User>
    {
        new User { Name = "Maria", Email = "maria@betrybe.com", Password = "123456", Country = "Brasil"},
        new User { Name = "Joana", Email = "joana@betrybe.com", Password = "123456", Country = "Argentina"},
        new User { Name = "Rebeca", Email = "rebeca@betrybe.com", Password = "123456", Country = "México"},
    };
    public virtual User Get(User user)
    {
        var foundedUser = _users.Where(u => u.Email == user.Email && u.Password == user.Password);
        if (foundedUser.Count() >  0) return foundedUser.First();
        return null;
    }
}