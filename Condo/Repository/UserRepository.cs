using Condo.Models;
using Condo.Repository.Interfaces;
using Condo.Context.Interfaces;
using Microsoft.EntityFrameworkCore;
using Condo.Exceptions;

namespace Condo.Repository;

public class UserRepository : IUserRepository
{
    protected readonly IDatabaseContext _context;

    public UserRepository(IDatabaseContext context)
    {
        _context = context;
    }
    public User Add(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
        return _context.Users.Include(u => u.Person).FirstOrDefault(u => u.Id == user.Id)!;
    }

    public void ChangePassword(int Id, string NewPassword)
    {
        User? user = _context.Users.Find(Id);
        if (user == null) throw new NotFoundException("User not found");
        user.Password = NewPassword;
        _context.Users.Update(user);
        _context.SaveChanges();
    }

    public User? GetByEmail(string email)
    {
        return _context.Users.Include(u => u.Person).FirstOrDefault(u => u.Email == email);
    }

    public User GetById(int Id)
    {
        return _context.Users.Include(u => u.Person).FirstOrDefault(u => u.Id == Id)!;
    }

    public User GetByUnity(int UnityId)
    {
        User? user = _context.Residents.Include(r => r.Person)
                          .ThenInclude(p => p.User)
                          .Where(r => r.UnityId == UnityId && r.Person.User.Email != null)
                          .Select(r => r.Person.User)
                          .FirstOrDefault();
        if (user == null) throw new NotFoundException("User not found on this unity");
        return user;
    }
}