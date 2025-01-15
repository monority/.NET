Console.WriteLine("Enter the rate of growing ");
double rate = 1+ 0.89/100;
double town_population = 96809;
int year = 2015;
int count = 0;


while (town_population < 120000)
{
    year++;
    count++;
    town_population *= rate;
}
Console.WriteLine($"{count} years, we will be in {year}");
Console.WriteLine($"{Math.Floor(town_population)} habitants in {year}");