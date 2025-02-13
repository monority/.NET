using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercice4.Models;
using Microsoft.EntityFrameworkCore;

namespace Exercice4.Data
{

    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
	
        public DbSet<GraDino> GraDinos { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Data Source=(localdb)\EFCore;Integrated Security=True");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<GraDino>().HasData(new GraDino() { Id = 1, NickName = "Mols", height = 150, weight = 50, specy = "Ravager" });

		}


	}
}
