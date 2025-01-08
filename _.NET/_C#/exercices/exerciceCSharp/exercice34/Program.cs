List<string> names = new List<string>()
{
    "Alice",
    "Bob",
    "Charlotte",
    "Daniel",
    "Emma",
    "Frank",
    "Grace",
    "Henry",
    "Isabella",
    "Jack"
};
int choice;

do
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("---------- Big DRAW -----------");
    Console.ResetColor();
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("1- Draw");
    Console.WriteLine("2- List of people already drawn");
    Console.WriteLine("3- List of people not drawn");
    Console.WriteLine("0- Leave");
    choice = Convert.ToInt32(Console.ReadLine());
    switch (choice)
    {
        case 1:
            Random random = new Random();
            int randomNumber = random.Next(0, names.Count);
            Console.Write(names.Count);
            names.RemoveAt(randomNumber);
            Console.WriteLine($"Player draw {names[randomNumber]}");
            break;
    }
} while (choice != 0);