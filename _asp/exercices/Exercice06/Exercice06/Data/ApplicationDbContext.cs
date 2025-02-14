using Exercice06.Entities;
using Exercice06.Models;
using Microsoft.EntityFrameworkCore;

namespace Exercice06.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<MovieViewModel> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieViewModel>().HasData(new MovieViewModel() { Id = 1, Title = "Mols",Director = "Lol" , PictureUrl = "", Duration = 120 , Status= 0 });

        }

    }
}
