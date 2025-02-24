using System;
using System.Reflection.Metadata;
using ContactWithDtos.Models;
using ExercicePizza.Models;
using ExercicePizza.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace ExercicePizza.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Pizza> Pizzas { get; set; }
    public DbSet<Ingredients> Ingredients { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pizza>().HasData(
            new Pizza()
            {
                Id = 1,
                Name = "Margerita",
                Description = "Best one",
                Price = 12.90M,
                Status = Status.vegetarian
            }
        );

        modelBuilder.Entity<Ingredients>().HasData(
            new Ingredients()
            {
                Id = 1,
                Name = "carot",
                Description = "good vegetable",
                PizzaId = 1
            }
        );

        modelBuilder.Entity<Pizza>()
            .HasMany(p => p.Ingredients)
            .WithOne()
            .HasForeignKey(i => i.PizzaId);
    }
}
