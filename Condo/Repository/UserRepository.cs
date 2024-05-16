using Condo.Models;
using Condo.Repository.Interfaces;
using Condo.Context.Interfaces;
using Microsoft.EntityFrameworkCore;

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
        if (user == null) throw new Exception("User not found");
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
}