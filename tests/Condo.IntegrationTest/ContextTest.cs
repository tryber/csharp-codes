using Condo.Context.Interfaces;
using Condo.Models;
using Microsoft.EntityFrameworkCore;

namespace Condo.IntegrationTest;

public class ContextTest : DbContext, IDatabaseContext
{
    public ContextTest(DbContextOptions<ContextTest> options) : base(options) {

    }

    public DbSet<Condominium> Condominiums { get; set; } = null!;
    public DbSet<Unity> Unities { get; set; } = null!;
    public DbSet<Resident> Residents { get; set; } = null!;
    public DbSet<Person> Person { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Access> AccessControl { get; set; } = null!;


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
        
        modelBuilder.Entity<Access>()
                    .HasOne<Unity>(a => a.Unity)
                    .WithMany(u => u.AccessControl)
                    .HasForeignKey(a => a.UnityId);

        modelBuilder.Entity<Access>()
                    .HasOne<Person>(a => a.Person)
                    .WithMany(p => p.AccessControl)
                    .HasForeignKey(a => a.PersonId);
    }





}