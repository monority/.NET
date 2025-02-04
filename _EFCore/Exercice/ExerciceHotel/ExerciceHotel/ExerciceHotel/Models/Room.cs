using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciceHotel.Models
{
	internal class Room
	{
		public int Id { get; set; }
		public string Status { get; set; } = "Free";
		public int BedNumber { get; set; }
		public decimal price;
	}
}
