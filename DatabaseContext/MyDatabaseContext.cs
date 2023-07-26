using Microsoft.EntityFrameworkCore;
using GetActive_API.Models;
using Microsoft.Extensions.Configuration;
namespace GetActive_API.DatabaseContext;

public class MyDatabaseContext : DbContext
{
    protected readonly IConfiguration _configuration;

        public MyDatabaseContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        
        // optionsBuilder.UseInMemoryDatabase(databaseName: "ActiveDb");
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("GetActiveDatabase"));
    }


    public DbSet<Workout> workouts { get; set; }
    public DbSet<Exercise> exercises { get; set; }
    public DbSet<Post> fitness_posts { get; set; }
}