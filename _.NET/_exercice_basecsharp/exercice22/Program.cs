Console.WriteLine("Enter the number of lines ");
int height = Convert.ToInt32(Console.ReadLine());


for (int i = 0; i < height; i++)
{
    for (int j = 0; j < height - i; j++) 
    {
        Console.Write(" ");
    }

    for (int k = 0; k < (2 * i + 1); k++)
    {
        Console.Write("*");
    }
    Console.WriteLine(); 
}

