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
		[MinLength(3), MaxLength(30)]
		public string? Nickname { get; set; }
		[MinLength(1), MaxLength(100)]

		public int? HealthPoints { get; set; }
		[MaxLength(100)]

		public int? Armor { get ; set; }
		[MinLength(1), MaxLength(100)]

		public int? Damage { get; set ; }
		public DateTime DateCreation { get; set; }

		public int? KillCounts { get; set; } = 0;
		public bool CanGetKill { get ;  set; }
	}
	}

