using Auth.Models;

namespace Auth.Repository;

public class UserRepository
{
    public virtual User Get(User user)
    {
        return user;
    }
}