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
    public DbSet<Unity> Unities { get; set; } = null!;
    public DbSet<Resident> Residents { get; set; } = null!;
    public DbSet<Person> Person { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = "Server=localhost;Database=Condo;User=SA;Password=SqlCondol12345!;TrustServerCertificate=True";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Condominium>()
                    .HasMany(c => c.Units)
                    .WithOne(u => u.Condominium)
                    .HasForeignKey(u => u.CondominiumId);
        
        modelBuilder.Entity<Resident>()
                    .HasOne<Unity>(r => r.Unity)
                    .WithMany(u => u.Residents)
                    .HasForeignKey(r => r.UnityId);

        modelBuilder.Entity<Resident>()
                    .HasOne<Person>(r => r.Person)
                    .WithMany(p => p.Residents)
                    .HasForeignKey(r => r.PersonId);
    }





}