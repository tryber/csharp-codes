using Condo.Models;
using Microsoft.EntityFrameworkCore;

namespace Condo.Context.Interfaces;

public interface IDatabaseContext
{
    public DbSet<Condominium> Condominiums { get; set; }
    public int SaveChanges();

}