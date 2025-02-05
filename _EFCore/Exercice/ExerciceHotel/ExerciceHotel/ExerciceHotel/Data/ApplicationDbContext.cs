using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExerciceHotel.Models;
using ExerciceHotel.Models.Enums;
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

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder
				.Entity<Room>()
				.Property(r => r.Status)
				.HasConversion(
					v => v.ToString(),
					v => (RoomStatus)Enum.Parse(typeof(RoomStatus), v));

			builder.Entity<Reservation>()
				.Property(r => r.Status)
				.HasConversion(
				v => v.ToString(),
				v => (ReservationStatus)Enum.Parse(typeof(ReservationStatus), v));
			builder.Entity<Hotel>().HasData(new Hotel() { Id = 1, Name = "Deluxe", Rooms = { } });
		}


	}
}
