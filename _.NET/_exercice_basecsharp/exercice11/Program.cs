Console.WriteLine("Enter age of your child");
int input = Convert.ToInt32(Console.ReadLine());


if (input <= 6)
{
    Console.WriteLine("Your child is a baby");
}
else if (input <= 8)
{
    Console.WriteLine("Your child is a poussin");
}
else if (input <= 10)
{
    Console.WriteLine("Your child is a pupill");
}
else if (input <= 12)
{
    Console.WriteLine("Your child is a minim");
}
else    if (input > 13)
{
    Console.WriteLine("Your child is a cadet");
}