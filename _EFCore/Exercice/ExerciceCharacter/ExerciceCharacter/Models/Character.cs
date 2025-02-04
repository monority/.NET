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
		public int? MaxHP { get; set; }
		public int? MaxArmor {  get; set; }
		public int? Damage { get; set; }
		public DateTime DateCreation { get; set; }
		public int? KillCounts { get; set; } = 0;


		public override string ToString()
		{
			return $@"
┌──────────────────────────────┐
│ {Nickname,-20}       │
├──────────────────────────────┤
│ HP     : {HealthPoints,5}    │
│ Armor  : {Armor,5}    │
│ DMG    : {Damage,5}    │
│ Kills  : {KillCounts,5}    │
├──────────────────────────────┤
│ Created: {DateCreation} │
└──────────────────────────────┘";
		}
	}

	}

