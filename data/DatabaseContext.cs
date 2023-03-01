using Microsoft.EntityFrameworkCore;

namespace data;

public class DatabaseContext : DbContext
{

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    { }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING") ??
                                  "Server=localhost;Database=kingscourt;User=root;Password=root;";
        optionsBuilder.UseSqlServer(connectionString);
    }
}