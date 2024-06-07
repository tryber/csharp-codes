using Condo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Condo.Context.Interfaces;

public interface IDatabaseContext
{
    public DbSet<Condominium> Condominiums { get; set; }
    public DbSet<Unity> Unities { get; set; }
    public DbSet<Resident> Residents { get; set; }
    public DbSet<Person> Person { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Access> AccessControl { get; set; }
    public int SaveChanges();
    public EntityEntry Entry(object entity);

}