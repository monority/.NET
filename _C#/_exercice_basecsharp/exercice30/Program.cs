Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("---------- Contact Manager -----------");
Console.ResetColor();
Console.WriteLine("Contact number ? : ");
int input = Convert.ToInt32(Console.ReadLine());
int choice;
Console.Clear();
string[] values = new string[input];
do
{

    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine($"---------- Contact List ({input}) -----------");
    Console.ResetColor();
    Console.WriteLine("1 - Add Contact");
    Console.WriteLine("2 - Show Contact");
    Console.WriteLine("3 - Change contact number");
    Console.WriteLine("4 - Leave application");

    choice = Convert.ToInt32(Console.ReadLine());
    Console.Clear();
    switch (choice)
    {   
        case 1:
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("---------- Add Contact -----------");
            Console.ResetColor();
            for (int i = 0; i < values.Length; i++)
            {
                Console.Write($"Contact n°{i + 1} : {values[i]}");
                values[i] = Console.ReadLine();
            }

            Console.Clear();
            break;
        case 2: 
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("---------- Show Contact -----------");
            Console.ResetColor();
            for (int i = 0; i < values.Length; i++)
            {
                Console.WriteLine($"Contact n°{i + 1} : {values[i]}");
            }
            break;
        case 3 :
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("---------- Change number of Contact -----------");
            Console.ResetColor();
            Console.WriteLine("Contact number ? : ");
            input = Convert.ToInt32(Console.ReadLine());
            Array.Resize(ref values, input);
            Console.Clear();
            break;
    }
} while (choice != 4);