using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciceHotel.Models
{
	internal class Client
	{
		[Key]
		public int Id { get; set; }
		[MaxLength(15)]
		public string? FirstName { get; set; }
		[MaxLength(15)]
		public string? LastName { get; set; }
		[MaxLength(15)]

		public string? PhoneNumber { get; set; }
		public List<Reservation> Reservations { get; set; } = []; // new()

	}
}
