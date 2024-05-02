using Condo.Context.Interfaces;
using Condo.Models;
using Microsoft.EntityFrameworkCore;

namespace Condo.Context;

public class DatabaseContext : DbContext, IDatabaseContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) {

    }
    public DatabaseContext() {}

    public DbSet<Condominium> Condominiums { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = "Server=localhost;Database=Condo;User=SA;Password=SqlCondol12345!;TrustServerCertificate=True";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }




}