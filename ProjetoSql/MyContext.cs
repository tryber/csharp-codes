using Microsoft.EntityFrameworkCore;
namespace ProjetoSql;

public class MyContext : DbContext
{
    // Criar um construtor que envia as configurações de inicialização
    // para o construtor da classe pai DbContext
    public MyContext(DbContextOptions<MyContext> options)
            : base(options)
    {}

    public DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Verificamos se o banco de dados já foi configurado
        if (!optionsBuilder.IsConfigured)
        {
            // Buscamos o valor da connection string armazenada nas variáveis de ambiente
            var connectionString = "Server=127.0.0.1;Database=trybe_db;User=SA;Password=Password12";

            // Executamos o método UseSqlServer e passamos a connection string a ele
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}