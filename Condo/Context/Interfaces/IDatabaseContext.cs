using Condo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Condo.Context.Interfaces;

public interface IDatabaseContext
{
    public DbSet<Condominium> Condominiums { get; set; }
    public int SaveChanges();
    public EntityEntry Entry(object entity);

}