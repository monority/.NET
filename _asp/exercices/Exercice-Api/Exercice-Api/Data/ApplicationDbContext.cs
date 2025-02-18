using Exercice_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Exercice_Api.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Contact> Contacts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Contact>().HasData(new Contact()
        {
            Id = 1,
            FirstName = "Denis",
            LastName = "Okijed",
            BirthDate = new DateOnly(1998, 12, 12),
            PhoneNumber = "+212315161",
            Email = "example@test.fr",
            Gender = "F",
        },
        new Contact()
        {
            Id = 2,
            FirstName = "Alicia",
            LastName = "Dsze",
            BirthDate = new DateOnly(1994, 12, 12),
            PhoneNumber = "+21241515",
            Email = "example2@test.fr",
            Gender = "M",
        }

        );

    }

}
