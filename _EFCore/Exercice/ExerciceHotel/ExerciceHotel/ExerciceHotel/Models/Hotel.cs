using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciceHotel.Models
{
	internal class Hotel
	{
		public int Id { get; set; }
		[MaxLength(15)]
		public string? Name { get; set; }

		public List<Client> Clients = new List<Client>();
		public List<Client> Rooms = new List<Client>();
		public List<Reservation> Reservations = new List<Reservation>();

	}
}
