using data.models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace data
{
    public class DatabaseContext : DbContext
    {
        // dotnet ef migrate add InitialCreate -p "../data"
        // dotnet ef database update
        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        { }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING") ??
                                      "Server=localhost;Port=3306;Database=kingscourt;User=root;Password=root;";
            optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 26)));
        }
    }
}