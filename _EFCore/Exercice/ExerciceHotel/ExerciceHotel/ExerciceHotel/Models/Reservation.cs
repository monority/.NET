using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciceHotel.Models;
using ExerciceHotel.Models.Enums;

internal class Reservation
{
	public int Id { get; set; }
	public ReservationStatus Status { get; set; }

	public Room? Room { get; set; } 
	public Client? Client { get; set; }

}
