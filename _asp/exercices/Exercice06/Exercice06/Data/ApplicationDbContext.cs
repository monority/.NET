using Exercice06.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo01.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }

    }
}
