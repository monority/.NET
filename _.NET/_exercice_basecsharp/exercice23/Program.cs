Console.WriteLine("Enter the number of lines ");
int height = Convert.ToInt32(Console.ReadLine());
Random random = new Random();
List<ConsoleColor> ball_colors = new List<ConsoleColor>()
{
    ConsoleColor.Red,
    ConsoleColor.Magenta,
    ConsoleColor.Blue,
    ConsoleColor.Yellow,
};

while (true)
{
    for (int row = 1; row <= height; row++)
    {
        for (int space = 1; space <= height - row; space++)
        {
            Console.Write(" ");
        }

        if (row == 1)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("🌟");
            continue;
        }

        for (int star = 1; star <= (2 * row - 1); star++)
        {
            string symb;
            if (random.NextDouble() > 0.33)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                symb = "*";
            }
            else
            {
                Console.ForegroundColor = ball_colors[random.Next(ball_colors.Count)];
                symb = "o";
            }

            Console.Write(symb);
        }

        Console.WriteLine();
    }
    Thread.Sleep(1000);
    Console.Clear();
}