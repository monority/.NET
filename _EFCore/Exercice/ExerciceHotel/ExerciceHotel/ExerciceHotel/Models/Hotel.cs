using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciceHotel.Models
{
	internal class Hotel
	{
		public List<Client> Clients = new List<Client>();
		public List<Room> Rooms = new List<Room>();
		public List<Reservation> Reservations = new List<Reservation>();
	}
}
