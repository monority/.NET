using System;
using ContactWithDtos.Models;
using ExercicePizza.Models;
using Microsoft.EntityFrameworkCore;

namespace ExercicePizza.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Pizza> Pizzas { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

}
