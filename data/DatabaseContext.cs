using data.models;
using Microsoft.EntityFrameworkCore;

namespace data;

public class DatabaseContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Game> Games { get; set; }

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    { }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING") ??
                                  "Server=localhost;Database=kingscourt;User=root;Password=root;";
        optionsBuilder.UseSqlServer(connectionString);
    }
}