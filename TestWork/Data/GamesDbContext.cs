using Microsoft.EntityFrameworkCore;
using TestWork.Model;

namespace TestWork.Data;

public class GamesDbContext : DbContext
{
    public DbSet<Game?> Games { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Studio> Studios { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseNpgsql("Server=localhost;Port=5432;Username=test;Password=test;Database=aprikod");
    }
    
}