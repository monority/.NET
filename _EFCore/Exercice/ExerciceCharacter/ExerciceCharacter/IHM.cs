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
			Console.WriteLine("1 -- Create a Character");
			Console.WriteLine("2 -- Delete a Character");
			Console.WriteLine("3 -- Update a Charater");
			Console.WriteLine("4 -- Show all Characters");
			Console.WriteLine("5 -- Hit a Character YourSelf");
			Console.WriteLine("6 -- Combat a Character with a Character of your choice");
			Console.WriteLine("7 -- Show Characters that have superior average hp and armor");
			Console.WriteLine("8 -- Generate Random Characters");
			Console.WriteLine("9 -- Tournament");
			Console.WriteLine("10 -- Delete All Characters");
			Console.WriteLine("# -- Any to leave");
			Console.WriteLine("---------------------------------------------");

		}
		public static void CreateCharacter()
		{
			using var context = new ApplicationDbContext();

			var character = new Character();
			var characters = context.Characters.ToList();
			try
			{
				Console.WriteLine("Username : ");
				character.Nickname = Console.ReadLine();
				var find_character = characters.Find(c => c.Nickname == character.Nickname);
				if (find_character != null)
				{
					Console.WriteLine("Character already exist");
					return;
				}
				else
				{
					Console.WriteLine("Health Points");
					character.HealthPoints = Convert.ToInt32(Console.ReadLine());
					Console.WriteLine("Armor : ");
					character.Armor = Convert.ToInt32(Console.ReadLine());
					Console.WriteLine("Default Damage : ");
					character.Damage = Convert.ToInt32(Console.ReadLine());
					character.DateCreation = DateTime.Now;
					context.Characters.Add(character);
					context.SaveChanges();
					Console.WriteLine("Character Created");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
		public static void GenerateCharacters()
		{
			using var context = new ApplicationDbContext();

			Console.WriteLine("Automatic generation of characters");
			Console.WriteLine("How many characters you want to create ?");
			int nbrCharacters = Convert.ToInt32(Console.ReadLine());
			for (int i = 0; i < nbrCharacters; i++)
			{
				Random rdn = new Random();
				int max = rdn.Next(3, 12);
				int max_armor = rdn.Next(20, 150);
				int max_hp = rdn.Next(50, 150);
				int max_damage = rdn.Next(10, 25);
				var character = new Character();
				character.Nickname = GenerateName(max);
				character.Armor = max_armor;
				character.HealthPoints = max_hp;
				character.Damage = max_damage;
				character.DateCreation = DateTime.Now;
				context.Characters.Add(character);
			}
			context.SaveChanges();
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
			using var context = new ApplicationDbContext();
			ShowAllCharacters();
			Console.WriteLine("Enter Character name you want to delete");
			var character = context.Characters.FirstOrDefault(c => c.Nickname == Console.ReadLine());

			if (character != null)
			{
				if (character.Nickname == "God")
				{
					Console.WriteLine("You can't delete an admin");
				}
				else
				{
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

			}
			else
			{
				Console.WriteLine("Can't find the character");
			}
		}

		public static void ShowAllCharacters()
		{
			using var context = new ApplicationDbContext();

			var characters = context.Characters.ToList();

			foreach (var character in characters)
			{
				Console.WriteLine($"ID: {character.Id}, Nickname: {character.Nickname}, Hp: {character.HealthPoints}, Armor : {character.Armor}, Damage : {character.Damage}, kill : {character.KillCounts}");
			}
		}
		public static void UpdateCharacter()
		{
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
		public static void HitCharacterYourSelf()
		{
			using var context = new ApplicationDbContext();

			Console.WriteLine("Which character do you want to hit?");
			string nickname = Console.ReadLine();

			var character = context.Characters.FirstOrDefault(c => c.Nickname == nickname);
			if (character == null)
			{
				Console.WriteLine("Character was not found.");
				return;
			}

			if (character.Nickname == "God")
			{
				Console.WriteLine("You can't hit an admin!");
				return;
			}

			try
			{
				Console.WriteLine("Hit for how much?");
				int damage = Convert.ToInt32(Console.ReadLine());
				if (character.Armor > 0)
				{
					int? remainingDamage = damage - character.Armor;
					character.Armor = Math.Max(0, (int)(character.Armor - damage));

					if (remainingDamage > 0)
					{
						character.HealthPoints = Math.Max(0, (int)(character.HealthPoints - remainingDamage));
						Console.WriteLine($"Character lost {remainingDamage} health after armor was destroyed.");
					}
					else
					{
						Console.WriteLine($"Character lost {damage} armor.");
					}
				}
				else
				{

					character.HealthPoints = Math.Max(0, (int)(character.HealthPoints - damage));

					Console.WriteLine($"Character lost {damage} health.");
				}

				if (character.HealthPoints <= 0)
				{
					Console.WriteLine("No more life. Character deleted.");
					context.Characters.Remove(character);
				}
				context.SaveChanges();
				Console.WriteLine($"Remaining Armor: {character.Armor}");
				Console.WriteLine($"Remaining Health: {character.HealthPoints}");
			}
			catch (FormatException)
			{
				Console.WriteLine("Invalid input. Please enter a valid number for damage.");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"An error occurred: {ex.Message}");
			}
		}

	
		public static void DeleteAllCharacters()
		{
			using var context = new ApplicationDbContext();
			Console.WriteLine("Are you sure you want to delete all characters except the one with ID 0? (y/n)");
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
		public static void CombatACharacter()
		{
			using var context = new ApplicationDbContext();
			ShowAllCharacters();
			Console.WriteLine("Which character do you want to chose?");
			string nickname = Console.ReadLine();
			var character = context.Characters.FirstOrDefault(c => c.Nickname == nickname);
			Random rnd =	new Random();
			int rndCharacter = rnd.Next(1, context.Characters.Count());
			Console.WriteLine(rndCharacter);
	
			var combat_character = context.Characters.FirstOrDefault(c => c.Id == rndCharacter);
			Console.WriteLine($"{combat_character.Nickname} was chosen");
			if (character == null || combat_character == null)
			{
				Console.WriteLine("Character was not found.");
				return;
			}

			if (character.Nickname == "God"  || combat_character.Nickname == "God")
			{
				Console.WriteLine("You can't chose an admin!");
				return;
			}

			try
			{

				if (combat_character.Armor > 0)
				{
					int? remainingDamage = character.Damage - combat_character.Armor;
					combat_character.Armor = Math.Max(0, (int)(combat_character.Armor - character.Damage));

					if (remainingDamage > 0)
					{
						combat_character.HealthPoints = Math.Max(0, (int)(combat_character.HealthPoints - remainingDamage));
						Console.WriteLine($"Character lost {remainingDamage} health after armor was destroyed.");
					}
					else
					{
						Console.WriteLine($"Character lost {character.Damage} armor.");
					}
				}
				else
				{

					combat_character.HealthPoints = Math.Max(0, (int)(combat_character.HealthPoints - character.Damage));

					Console.WriteLine($"{combat_character.Nickname} lost {character.Damage} health.");
				}

				if (combat_character.HealthPoints <= 0)
				{
					Console.WriteLine("No more life. Character deleted.");
					character.KillCounts++;
					context.Characters.Remove(combat_character);
				}
				context.SaveChanges();
				Console.WriteLine($"Remaining Armor: {combat_character.Armor}");
				Console.WriteLine($"Remaining Health: {combat_character.HealthPoints}");
			}
			catch (FormatException)
			{
				Console.WriteLine("Invalid input. Please enter a valid number for damage.");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"An error occurred: {ex.Message}");
			}
		}
		public static void AverageLife()
		{
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

					Console.WriteLine($"Character that has higher than average armor and hp : ");
			foreach (var character in characters)
			{
				if (character.Armor  + character.HealthPoints > result)
				{
					Console.WriteLine(character.Nickname);
				}
			}
		}

		public static void Tournament()
		{
			using var context = new ApplicationDbContext();
			var characters = context.Characters.ToList();
		}
		public static void Start()
		{
			while (true)
			{
				ShowMenu();

				string input = Console.ReadLine();

				switch (input)
				{
					case "1": CreateCharacter();

						break;
					case "2": DeleteCharacter();
						break;
					case "3":UpdateCharacter();
						break;
					case "4":
						ShowAllCharacters();
						break;
					case "5": HitCharacterYourSelf();
						break;
					case "6": CombatACharacter();
						break;
					case "7": AverageLife();
						break;
					case "8": GenerateCharacters();
						break;
					case "9":  Tournament();
						break;
					case "10": DeleteAllCharacters();
						break;
					default: Environment.Exit(0);
						break;

				}
			}
		}
	}
}

