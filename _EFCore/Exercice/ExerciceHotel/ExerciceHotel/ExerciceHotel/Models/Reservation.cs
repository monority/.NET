using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciceHotel.Models
{
	internal class Reservation
	{
		public int Id { get; set; }
		public string Status { get; set; }
		public List<Room> Rooms { get; set; } = new List<Room>();
		public Client Client { get; set; }
	}
}
