using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ExerciceHotel.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
namespace ExerciceHotel.Models;

internal class Room
{
	[Key]
	public int RoomNumber { get; set; }

	[MinLength(3), MaxLength(15)]
	public RoomStatus Status { get; set; }
	[MaxLength(2)]
	public sbyte BedNumber { get; set; }
	[Precision(10, 5)]
	public decimal Price { get; set; }
	public List<Reservation> Reservations { get; set; }
}
