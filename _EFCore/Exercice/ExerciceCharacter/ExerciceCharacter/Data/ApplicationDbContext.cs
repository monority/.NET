using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExerciceCharacter.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo01.Data
{

    internal class ApplicationDbContext : DbContext
    {

		public ApplicationDbContext() : base()
		{

		}
		public DbSet<Character> Characters { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Data Source=(localdb)\EFCore;Integrated Security=True");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Character>().HasData(new Character() { Id = 1, Nickname = "God", Armor = 100, HealthPoints = 100, Damage = 1000, DateCreation = DateTime.Now, KillCounts = 0});

		}


	}
}
