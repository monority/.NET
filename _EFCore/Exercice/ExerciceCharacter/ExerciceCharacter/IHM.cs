using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo01.Data;
using ExerciceCharacter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace ExerciceCharacter
{
	internal interface IHM
	{
		public static void ShowMenu()
		{

			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("---------- Character Combat -------------\n");
			Console.ResetColor();
			Console.WriteLine("1 -- Generate Characters");
			Console.WriteLine("2 -- Delete a Character");
			Console.WriteLine("3 -- Update a Charater");
			Console.WriteLine("4 -- Show all Characters");
			Console.WriteLine("5 -- Delete All Characters");
			Console.WriteLine("6 -- Best Characters");
			Console.WriteLine("7 -- Tournament");
			Console.WriteLine("# -- Any to leave");
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("---------------------------------------------");
			Console.ResetColor();

		}

		public static void GenerateCharacters()
		{
			Console.Clear();
			using var context = new ApplicationDbContext();
			Console.WriteLine("Automatic generation of characters");
			Console.WriteLine("How many characters you want to create ?");
			if (int.TryParse(Console.ReadLine(), out int nbrCharacters))
			{
				for (int i = 0; i < nbrCharacters; i++)
				{
					Random rdn = new Random();
					int max = rdn.Next(3, 12);
					int maxArmor = rdn.Next(20, 150);
					int maxHP = rdn.Next(50, 150);
					int maxDMG = rdn.Next(10, 25);
					var character = new Character
					{
						Nickname = GenerateName(max),
						Armor = maxArmor,
						HealthPoints = maxHP,
						Damage = maxDMG,
						DateCreation = DateTime.Now,
						MaxHP = maxHP,
						MaxArmor = maxArmor,
					};
					context.Characters.Add(character);
					Console.WriteLine(character.ToString());
				}
				context.SaveChanges();
			}
			else
			{
				Console.WriteLine("Invalid input. Please enter a valid number.");
			}
		}
		public static string GenerateName(int len)
		{
			Random r = new Random();
			string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
			string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
			string Name = "";
			Name += consonants[r.Next(consonants.Length)].ToUpper();
			Name += vowels[r.Next(vowels.Length)];
			int b = 2;
			while (b < len)
			{
				Name += consonants[r.Next(consonants.Length)];
				b++;
				Name += vowels[r.Next(vowels.Length)];
				b++;
			}

			return Name;


		}
		public static void DeleteCharacter()
		{
			Console.Clear();

			using var context = new ApplicationDbContext();
			ShowAllCharacters();
			Console.WriteLine("Enter Character name you want to delete");
			var character = context.Characters.FirstOrDefault(c => c.Nickname == Console.ReadLine());

			if (character != null)
			{
				if (character.Nickname == "God")
				{
					Console.WriteLine("You can't delete an admin");
					return;
				}
				try
				{
					context.Characters.Remove(character);
					Console.WriteLine("Character was found and deleted");
					context.SaveChanges();
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
			else
			{
				Console.WriteLine("Can't find the character");
			}
		}

		public static void ShowAllCharacters()
		{
			Console.Clear();
			using var context = new ApplicationDbContext();
			var characters = context.Characters.ToList();

			foreach (var character in characters)
			{
				Console.WriteLine(character.ToString());
			}
		}
		public static void UpdateCharacter()
		{
			Console.Clear();

			using var context = new ApplicationDbContext();
			Console.WriteLine("Which character you want to modify #name");

			var character = context.Characters.FirstOrDefault(c => c.Nickname == Console.ReadLine());
			if (character != null)
				if (character.Nickname == "God")
				{
					Console.WriteLine("You can't modify an admin !");
				}
				else {
					{
						try
						{
							var updateCharacter = new Character();
							Console.WriteLine($"Enter a new nickname for {character.Nickname}");
							updateCharacter.Nickname = Console.ReadLine();
							Console.WriteLine($"Enter a new armor value : {character.Armor}");
							updateCharacter.Armor = Convert.ToInt32(Console.ReadLine());
							Console.WriteLine($"Enter a new hp value : {character.HealthPoints}");
							updateCharacter.HealthPoints = Convert.ToInt32(Console.ReadLine());
							Console.WriteLine($"Enter a new base damage value : {character.Damage}");
							context.SaveChanges();
							Console.WriteLine("Character was updated and saved");
						}
						catch (Exception ex)
						{
							Console.WriteLine(ex.Message);
						}
					}
				}
			else
			{
				Console.WriteLine("Character was not found");
				return;
			}
		}
		public static void DeleteAllCharacters()
		{
			Console.Clear();

			using var context = new ApplicationDbContext();
			Console.WriteLine("Are you sure you want to delete all characters ? (y/n)");
			string choice = Console.ReadLine();
			if (choice != null && choice.ToLower() == "y")
			{
				var charactersToDelete = context.Characters.Where(c => c.Id != 1).ToList();
				context.Characters.RemoveRange(charactersToDelete);
				context.SaveChanges();
				Console.WriteLine("All characters except God have been deleted.");
			}
			else
			{
				Console.WriteLine("Operation cancelled.");
			}
	}
		public static void Tournament()
		{
			Console.Clear();
			Random rnd = new Random();
			using var context = new ApplicationDbContext();
			ShowAllCharacters();
			Console.WriteLine("Which character do you want to choose?");
			string? nickname = Console.ReadLine();
			var character = context.Characters.FirstOrDefault(c => c.Nickname == nickname);
			int rndCharacter = context.Characters.OrderBy(c => Guid.NewGuid()).FirstOrDefault()?.Id ?? 0;
			var combatCharacter = context.Characters.FirstOrDefault(c => c.Id == rndCharacter);

			if (character == null || combatCharacter == null)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Character was not found.");
				Console.ResetColor();
				return;
			}

			if (character.Nickname == "God" || combatCharacter.Nickname == "God")
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("You can't choose an admin!");
				Console.ResetColor();
				return;
			}

			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine($"\n{combatCharacter.Nickname} was chosen as your opponent!");
			Console.ResetColor();

			try
			{
				int? stockHPCombat = combatCharacter.HealthPoints;
				int? stockAMRCombat = combatCharacter.Armor;
				int? stockHPCharacter = character.HealthPoints;
				int? stockAMRCharacter = character.Armor;

				while (character.HealthPoints > 0 && combatCharacter.HealthPoints > 0)
				{
					Console.Clear();
					DrawCombatInterface(character, combatCharacter);

					if (combatCharacter.Armor > 0 || character.Armor > 0)
					{
						int? remainingDamage = character.Damage - combatCharacter.Armor;
						int? remainingDamageCharacter = combatCharacter.Damage - character.Armor;
						combatCharacter.Armor = Math.Max(0, (combatCharacter.Armor ?? 0) - (character.Damage ?? 0));
						character.Armor = Math.Max(0, (character.Armor ?? 0) - (combatCharacter.Damage ?? 0));

						if (remainingDamage > 0)
						{
							combatCharacter.HealthPoints = Math.Max(0, (combatCharacter.HealthPoints ?? 0) - remainingDamage.Value);
						}
						if (remainingDamageCharacter > 0)
						{
							character.HealthPoints = Math.Max(0, (character.HealthPoints ?? 0) - remainingDamageCharacter.Value);
						}

						Thread.Sleep(500);
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine($"\nOpponent lost {remainingDamage} health after armor was destroyed.");
						Console.WriteLine($"Character lost {remainingDamageCharacter} health after armor was destroyed.");
						Console.ResetColor();
					}
					else
					{
						combatCharacter.HealthPoints = Math.Max(0, (combatCharacter.HealthPoints ?? 0) - (character.Damage ?? 0));
						character.HealthPoints = Math.Max(0, (character.HealthPoints ?? 0) - (combatCharacter.Damage ?? 0));

						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine($"\n{combatCharacter.Nickname} lost {character.Damage} health.");
						Console.WriteLine($"{character.Nickname} lost {combatCharacter.Damage} health.");
						Console.ResetColor();
					}

					Thread.Sleep(1000);
				}

				if (combatCharacter.HealthPoints <= 0)
				{
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine("\nYou won, your opponent is dead.");
					Console.ResetColor();
					Thread.Sleep(500);
					character.KillCounts++;
					character.HealthPoints = stockHPCharacter;
					combatCharacter.HealthPoints = stockHPCombat;
					Console.ForegroundColor = ConsoleColor.Cyan;
					Console.WriteLine("Your character got healed.");
					Console.ResetColor();
					context.Characters.Remove(combatCharacter);
				}
				if (character.HealthPoints <= 0)
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("\nYou lose, your character died.");
					Console.ResetColor();
					Thread.Sleep(500);
					Console.ForegroundColor = ConsoleColor.Cyan;
					Console.WriteLine("Opponent got healed.");
					Console.ResetColor();
					combatCharacter.HealthPoints = stockHPCombat;
					combatCharacter.Armor = stockAMRCombat;
					combatCharacter.KillCounts++;
					context.Characters.Remove(character);
				}

				context.SaveChanges();
			}
			catch (FormatException)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Invalid input. Please enter a valid number for damage.");
				Console.ResetColor();
			}
			catch (Exception ex)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine($"An error occurred: {ex.Message}");
				Console.ResetColor();
			}
		}

		private static void DrawCombatInterface(Character character, Character combatCharacter)
		{
			Console.WriteLine("=============================================");
			Console.WriteLine("                  COMBAT                     ");
			Console.WriteLine("=============================================");
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine($" {character.Nickname} (You)");
			Console.WriteLine($" HP: {character.HealthPoints} | Armor: {character.Armor}");
			Console.ResetColor();
			Console.WriteLine("---------------------------------------------");
			Console.ForegroundColor = ConsoleColor.Magenta;
			Console.WriteLine($" {combatCharacter.Nickname} (Opponent)");
			Console.WriteLine($" HP: {combatCharacter.HealthPoints} | Armor: {combatCharacter.Armor}");
			Console.ResetColor();
			Console.WriteLine("=============================================");
		}
		public static void BestCharacters()
		{
			Console.Clear();

			using var context = new ApplicationDbContext();

			var characters = context.Characters.ToList();
			if (characters.Count == 0)
			{
				Console.WriteLine("No characters found.");
				return;
			}

			float totalArmor = 0;
			float totalHealthPoints = 0;
			float? result;
			foreach (var character in characters)
			{
				totalArmor += (float)character.Armor;
				totalHealthPoints += (float)character.HealthPoints;
			}

			float averageArmor = totalArmor / characters.Count;
			float averageHealthPoints = totalHealthPoints / characters.Count;
			result = averageArmor + averageHealthPoints;
			Console.WriteLine($"Average Armor: {averageArmor}");
			Console.WriteLine($"Average Health Points: {averageHealthPoints}");

					Console.WriteLine($"Character that have higher than average armor and hp : ");
			foreach (var character in characters)
			{
				if (character.Armor  + character.HealthPoints > result)
				{
					Console.WriteLine(character.Nickname);
				}
			}
		}

		
		public static void Start()
		{
			while (true)
			{
				ShowMenu();

				string input = Console.ReadLine();

				switch (input)
				{
					case "1": GenerateCharacters();
						break;
					case "2": DeleteCharacter();
						break;
					case "3":UpdateCharacter();
						break;
					case "4":ShowAllCharacters();
						break;
					case "5":DeleteAllCharacters();
						break;
					case "6": BestCharacters();
						break;
					case "7": Tournament();
						break;
					default: Environment.Exit(0);
						break;
				}
			}
		}
	}
}

