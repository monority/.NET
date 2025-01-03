Console.WriteLine("Is the letter a vowel ?");
string input = Console.ReadLine();

if ("aeiouAEIOU".Contains(input))
{
    Console.WriteLine("It's a vowel");
}
else
{
    Console.WriteLine("It's a consonant");
}
