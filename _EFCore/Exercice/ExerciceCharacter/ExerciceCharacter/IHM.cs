using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo01.Data;
using ExerciceCharacter.Models;

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
			Console.WriteLine("2 -- Show all Characters");
			Console.WriteLine("3 -- Hit a Character");
			Console.WriteLine("4 -- Show Characters that have superior average hp and armor");

		}
		public static void  CreateCharacter()
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
				Console.WriteLine("Character Created");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);

			}


		}
		public static void DeleteCharacter(Character character)
		{

		}
		public static void UpdateCharacter(Character character)
		{
		}
		public static void HitCharacter(Character character)
		{

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
					case "2":
						break;
					case "3":
						break;
					case "4":
						break;
					default: Environment.Exit(0);
						break;

				}
			}
		}
	}
}

