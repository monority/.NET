using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExerciceHotel.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo01.Data
{

    internal class ApplicationDbContext : DbContext
    {

		public ApplicationDbContext() : base()
		{

		}
		public DbSet<Room> Rooms { get; set; }
		public DbSet<Reservation> Reservations { get; set; }
		public DbSet<Client> Clients { get; set; }
		public DbSet<Hotel> Hotel { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Data Source=(localdb)\EFCore;Integrated Security=True");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Hotel>().HasData(new Hotel() { Id = 1, Nickname = "God", Armor = 100, HealthPoints = 100, Damage = 1000, DateCreation = DateTime.Now, KillCounts = 0});

		}


	}
}
