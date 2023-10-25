using Microsoft.EntityFrameworkCore;
namespace ProjetoSql;

public class MyContext : DbContext
{

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = "Server=127.0.0.1;Database=trybe_db;User=SA;Password=Password12;TrustServerCertificate=True";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}