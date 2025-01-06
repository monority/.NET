

Console.WriteLine("Enter your child age");
int choice = Convert.ToInt32(Console.ReadLine());

switch (choice)
{
    
    case >= 3 and <= 6 : Console.WriteLine("Baby"); break;
    case >= 7 and <= 8 : Console.WriteLine("Poussin"); break;
    case >= 9 and <= 10 : Console.WriteLine("Pupill"); break;
    case >= 11 and <= 12 : Console.WriteLine("Minim"); break;
    case >= 13 : Console.WriteLine("Cadet"); break;
}