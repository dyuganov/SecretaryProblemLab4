using Microsoft.EntityFrameworkCore;

namespace SecretaryProblem4.model.database;

public class ApplicationContext : DbContext
{
    //public DbSet<BContender> Contenders { get; set; } = null!;
    public DbSet<BTry> Tries { get; set; } = null!;
 
    public ApplicationContext()
    {
        Database.EnsureCreated();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=lab4db;Username=postgres;Password=postgres");
    }
}