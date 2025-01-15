
int max = 100;
int tries = 0;
Random rand = new Random();
int mystery_number = rand.Next(0, max);
int count = 0;
Console.WriteLine("---------- Mystery number ---------- \n \n");
do
{

    Console.WriteLine("Enter a value : ");
    int value = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine(mystery_number);
    if (value >= 0 && value < max)
    {
        count++;
        if (mystery_number == value)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"You won in {count} tries");
            Console.ResetColor(); 
            break;
        }
        else if (mystery_number > value)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Mystery number is higher");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Mystery number is lower");
            Console.ResetColor();
        }
    }
    else
    {
        Console.WriteLine("You did not enter a valid number");
    }
} while (count < 7);

