using System;
using Demo01.Data;
using ExerciceHotel.Models;
using ExerciceHotel.Models.Enums;
using ExerciceHotel.Repositories;

namespace ExerciceHotel.UI
{
	internal class MainUI
	{
		private readonly IRepository<Client, int> clientRepository;
		private readonly IRepository<Room, int> roomRepository;
		private readonly IRepository<Reservation, int> reservationRepository;

		public MainUI(IRepository<Client, int> clientRepository, IRepository<Room, int> roomRepository, IRepository<Reservation, int> reservationRepository)
		{
			this.clientRepository = clientRepository;
			this.roomRepository = roomRepository;
			this.reservationRepository = reservationRepository;
		}

		public static void SelectHotel(string hotelName)
		{
			ApplicationDbContext context = new ApplicationDbContext();
			Hotel? hotel = context.Hotel.FirstOrDefault(h => h.Name == hotelName);

			if (hotel != null)
			{
				Console.WriteLine($"Hotel selected: {hotel.Name}");
			}
			else
			{
				Console.WriteLine("Hotel not found");
				Environment.Exit(0);
			}
		}
		public static void ShowMenu()
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("╔════════════════════════════════════════╗");
			Console.WriteLine("║          HOTEL DELUXE MENU             ║");
			Console.WriteLine("╚════════════════════════════════════════╝");
			Console.ResetColor();

			Console.WriteLine();

			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine("1. Create client");
			Console.WriteLine("2. Show client list");
			Console.WriteLine("3. Show client reservations");
			Console.WriteLine("4. Add a reservation");
			Console.WriteLine("5. Show reservation list");
			Console.WriteLine("6. Generate rooms");
			Console.WriteLine("7. List all the rooms");
			Console.WriteLine("8. Generate Clients");
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("");
			Console.WriteLine("#. Any other key to leave");
			Console.ResetColor();

			Console.WriteLine();
		}



		public void AddClient()
		{
			Console.WriteLine("First Name : ");
			string? FName = Console.ReadLine();
			Console.WriteLine("Last Name : ");
			string? LName = Console.ReadLine();
			Console.WriteLine("Phone number : ");
			string? PhoneNumber = Console.ReadLine();

			Client client = new Client()
			{
				FirstName = FName,
				LastName = LName,
				PhoneNumber = PhoneNumber,
			};

			clientRepository.Add(client);
			Console.WriteLine("Client added successfully!");
		}

		public void AddReservation()
		{
			Console.WriteLine("Which client want to book ?(id)");
			int input = Convert.ToInt32(Console.ReadLine());
			var clientSelected = clientRepository.GetById(input);
			Console.WriteLine("Which Room you want to book ?(Room Number)");
			ShowAllRooms();
			int roomInput = Convert.ToInt32(Console.ReadLine());
			var roomSelected = roomRepository.GetById(roomInput);
			Reservation reserv = new Reservation()
			{
				Client = clientSelected,
				Room = roomSelected,
				Status = ReservationStatus.InProgress,
			};
			var reservation = reservationRepository.Add(reserv);

		}
		public void ShowClientList()
		{
			var clients = clientRepository.GetAll();
			foreach (var client in clients)
			{
				Console.WriteLine($"ID: {client.Id}, Name: {client.FirstName} {client.LastName}, Phone: {client.PhoneNumber}");
			}
		}
		public void ShowReservation()
		{
			Console.WriteLine("Enter Client id :");
			if (int.TryParse(Console.ReadLine(), out int input))
			{
				var reservations = reservationRepository.GetAll(r => r.Client != null && r.Client.Id == input);
				Console.WriteLine(reservations);
				if (reservations.Any())
				{
					foreach (var reservation in reservations)
					{
						var client = reservation.Client;
						var room = reservation.Room;
						if (client != null && room != null)
						{
							Console.WriteLine($"Reservation ID: {reservation.Id}");
							Console.WriteLine($"Client ID: {client.Id}, Name: {client.FirstName} {client.LastName}, Phone: {client.PhoneNumber}");
							Console.WriteLine($"Room Number: {room.RoomNumber}, Status: {room.Status}, Price: {room.Price}");
							Console.WriteLine($"Reservation Status: {reservation.Status}");
							Console.WriteLine("--------------------------------------------------");
						}
					}
				}
				else
				{
					Console.WriteLine("No reservations found for this client.");
				}
			}
			else
			{
				Console.WriteLine("Invalid Client ID.");
			}
		}

		public void GenerateRooms()
		{

			Console.WriteLine("How many rooms you want to generate ?");
			int input = Convert.ToInt32(Console.ReadLine());

			Random rdn = new Random();
			for (int i = 0; i < input; i++)
			{

				decimal randomPrice = rdn.Next(10, 150);
				int roomNumber = rdn.Next(1, 25);
				sbyte bedNumber = (sbyte)rdn.Next(1, 3);
				Room room = new Room()
				{
					Price = randomPrice,
					BedNumber = bedNumber,

				};
				roomRepository.Add(room);
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
		public void GenerateClients()
		{

			Console.WriteLine("How many clients you want to generate ?");
			int input = Convert.ToInt32(Console.ReadLine());

			Random rdn = new Random();
			for (int i = 0; i < input; i++)
			{
				string phoneNumber = rdn.Next(1, 20000).ToString();
				int max = rdn.Next(3, 8);
				Client client = new Client()
				{
					FirstName = GenerateName(max),
					LastName = GenerateName(max),
					PhoneNumber = phoneNumber,
				};
				clientRepository.Add(client);
			}
		}

		public void ShowAllRooms()
		{
			var rooms = roomRepository.GetAll();
			foreach (var room in rooms)
			{
				Console.WriteLine($"Room Number: {room.RoomNumber}, Bed Numbers: {room.BedNumber}, Price : {room.Price}, Status : {room.Status}");
			}
		}


		
		public void Start()
		{
			SelectHotel("Deluxe");
			while (true)
			{
				ShowMenu();

				string? input = Console.ReadLine();

				switch (input)
				{
					case "1":
						AddClient();
						break;
					case "2":
						ShowClientList();
						break;
					case "3":
						ShowReservation();
						break;
					case "4":
						AddReservation();
						break;
					case "6":
						GenerateRooms();
						break;
					case "7":
						ShowAllRooms();
						break;
					case "8": GenerateClients();
						break;
					default:
						Environment.Exit(0);
						break;
				}

			}
		}

		public void ShowClients()
		{

		}

		public void ShowClientReservations()
		{
		}

		public void CancelReservation()
		{

		}

		public void ShowReservations()
		{
		}
	}
}

