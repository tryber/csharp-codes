namespace School;
using Microsoft.EntityFrameworkCore;

public class SchoolContext : DbContext
{
    public SchoolContext(DbContextOptions options) : base(options) {}
    public SchoolContext() {}

    public DbSet<Student> Students{ get; set; } = null!;
    public DbSet<Teacher> Teachers { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = "Server=localhost;Database=School;User=SA;Password=SqlServer123!;TrustServerCertificate=True";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

}