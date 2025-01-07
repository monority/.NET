Console.WriteLine("How many notes ?");
int note = Convert.ToInt32(Console.ReadLine());
int max = 0;
int min = 20;
double average = 0;

for (int i = 0; i < note; i++)
{
    Console.WriteLine($"Enter note {i + 1}");
    int number = Convert.ToInt32(Console.ReadLine());
    if (number > max)
    {
        max = number;
    }

    if (number < min)
    {
        min = number;
    }

    average += number;

}
Console.WriteLine($"Max note : {max}");
Console.WriteLine($"Min note : {min}");
Console.WriteLine($"Average note : {average / note}");