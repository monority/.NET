Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("Is odd or even ?\n");
Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine("How many inputs for the array ?");
int input = Convert.ToInt32(Console.ReadLine());
int[] array = new int[input];
Random random = new Random();
Console.ForegroundColor = ConsoleColor.White;

for (int i = 0; i < array.Length; i++)
{
    int random_number = random.Next(0, 50);
    array[i] = random_number;
    if (array[i] % 2 == 0)
    {
        Console.WriteLine($"Value {array[i]} is even");
    }
    else
    {
        Console.WriteLine($"Value {array[i]} is odd");
    }
}