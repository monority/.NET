List<ConsoleColor> ball_colors = new List<ConsoleColor>()
{
    ConsoleColor.Red,
    ConsoleColor.Green,
};
Console.WriteLine("What's the instruction that allow to leave a C# loop ?" + "\n" +
                  "a) quit" + "\n" +
                  "b) continue" + "\n" +
                  "c) break" + "\n" +
                  "d) exit");


bool repeat = true;

while (repeat)
{
    Console.WriteLine("Enter your answer");
    char answer = Console.ReadKey().KeyChar;
    if (answer == 'c')
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nYou are correct");
        repeat = false;
        break;
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nYou are not correct");
        Console.ResetColor();
        
        string input = "";
        do
        {
            Console.WriteLine("Wanna retry ? y / n :");
            input = Console.ReadLine();
            if (input == "y")
            {
                repeat = true;
                break;
            }
            else if (input == "n")
            {
                repeat = false;
                break;
            }
            else
            {
                Console.WriteLine("\nWrong value");
            }

        } while (input != "n" || input != "y");
    }
}