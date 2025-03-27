using api_docker.Models;
using Microsoft.EntityFrameworkCore;

namespace api_docker.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Person> Contacts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var serverAddress = Environment.GetEnvironmentVariable("DB_HOST");
        var databaseName = Environment.GetEnvironmentVariable("DB_NAME");
        var username = Environment.GetEnvironmentVariable("DB_USER");
        var password = Environment.GetEnvironmentVariable("DB_PASSWORD");

        var connectionString = $"Server={serverAddress};Database={databaseName};Uid={username};Pwd={password};";

        optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0)));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>().HasData(new Person()
        {
            Id = 1,
            Name = "Denis",
            Email = "example@test.fr",
        },
        new Person()
        {
            Id = 2,
            Name = "Alicia",
            Email = "example@test.fr",
        });
    }
}
