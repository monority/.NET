using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo01.Data;
using ExerciceCharacter.Models;
using Microsoft.EntityFrameworkCore;
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
			Console.WriteLine("---------------------------------------------");

		}
		public static void CreateCharacter()
		{
			using var context = new ApplicationDbContext();

			var character = new Character();
			try
			{
				Console.WriteLine("Username : ");
				character.Nickname = Console.ReadLine();
				Console.WriteLine("Health Points");
				character.HealthPoints = Convert.ToInt32(Console.ReadLine());
				Console.WriteLine("Armor : ");
				character.Armor = Convert.ToInt32(Console.ReadLine());
				Console.WriteLine("Default Damage : ");
				character.Damage = Convert.ToInt32(Console.ReadLine());
				character.DateCreation = DateTime.Now;
				character.CanGetKill = true;
				context.Characters.Add(character);
				context.SaveChanges();
				Console.WriteLine("Character Created");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
		public static void DeleteCharacter()
		{
			using var context = new ApplicationDbContext();
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
						Console.WriteLine("Character was found");
						context.Characters.Remove(character);
						context.SaveChanges();
						Console.WriteLine("Character was deleted");
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

			var result = context.Characters.Select(c => c.Nickname).Distinct().ToList();
			result.ForEach(Console.WriteLine);

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
				Console.WriteLine("You can't modify an admin!");
				return;
			}

			try
			{
				Console.WriteLine("Hit for how much?");
				int damage = Convert.ToInt32(Console.ReadLine());
				int rest = 0;
				if (character.Armor > 0)
				{
					character.Armor -= damage;
					
					if (character.Armor < 0)
					{
						character.Armor = 0;
						Console.WriteLine("No more armor.");
					}
				}
				else
				{
					if (character.HealthPoints > 0)
					{
						character.HealthPoints -= damage;

						if (character.HealthPoints <= 0)
						{
							character.HealthPoints = 0;
							Console.WriteLine("No more life, the character is dead.");
							context.Characters.Remove(character);
						}
					}
				}

	
				context.SaveChanges();
			}
			catch (Exception ex)
			{
				Console.WriteLine($"An error occurred: {ex.Message}");
			}
		}
		public static void CombatCharacter()
		{
			using var context = new ApplicationDbContext();

			Console.WriteLine("Which character do you want to chose?");
			string nickname = Console.ReadLine();
			var character = context.Characters.FirstOrDefault(c => c.Nickname == nickname);
			Console.WriteLine("Which Character you want to combat ?");
			string combat_nick = Console.ReadLine();
			var combat_character = context.Characters.FirstOrDefault(character => character.Nickname == combat_nick);
			if (character == null)
			{
				Console.WriteLine("Character was not found.");
				return;
			}
			if (combat_character == null)
			{
				Console.WriteLine("Can't find the opponent");
				return;
			}

			if (character.Nickname == "God" || combat_character.Nickname == "God")
			{
				Console.WriteLine("You can't modify an admin!");
				return;
			}
			try
			{
				if (combat_character.Armor > 0)
				{
					combat_character.Armor -= character.Damage;
					Console.WriteLine($"{combat_character.Nickname} lost {character.Damage}");
					if (combat_character.Armor < 0)
					{

					}
					Console.WriteLine($"{combat_character.Armor} left");
				}
			}
			catch (Exception ex)
			{

				Console.WriteLine(ex.Message);
			}
			finally
			{
				context.SaveChanges();
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
					case "1": CreateCharacter();

						break;
					case "2": DeleteCharacter();
						break;
					case "3":UpdateCharacter();
						break;
					case "4":
						ShowAllCharacters();
						break;
					default: Environment.Exit(0);
						break;

				}
			}
		}
	}
}

