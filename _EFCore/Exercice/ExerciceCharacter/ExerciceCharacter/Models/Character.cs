using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciceCharacter.Models
{
	internal class Character
	{
		public int Id { get; set; }

		public string? Nickname { get; set; }
		[MinLength(1), MaxLength(50)]
		public int? HealthPoints { get; set; }

		public int? Armor { get; set; }

		public int? Damage { get; set; }
		public DateTime DateCreation { get; set; }
		public int? KillCounts { get; set; } = 0;

		public override string ToString()
		{
			return $"{Id}, {Nickname}, {HealthPoints}, {Armor}, {Damage}, {DateCreation}, {KillCounts}";
		}
	}

	}

