Console.WriteLine("Enter the value of AB");
double AB = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("Enter the value of AC");
double AC = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("Enter the value of BC");
double BC = Convert.ToDouble(Console.ReadLine());


if (AB == AC && BC == AC)
{
    Console.WriteLine("Your triangle is equilateral");
} 
else if (AB == AC || BC == AC || BC == AB )
{
    if (AB == AC)
    {
        Console.WriteLine("Iso in A");
    }
    if (BC == AC)
    {
        Console.WriteLine("Iso in C");
    }
    if (BC == AB)
    {
        Console.WriteLine("Iso in B");
    }   

}
else
{
    Console.WriteLine("Not iso");
}