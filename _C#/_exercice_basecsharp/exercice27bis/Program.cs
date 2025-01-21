for (int i = 1; i <= 100; i++)
{
    string ouput = "";
    if (i % 3 == 0)
    {
        ouput = "Fizz";
    }
    if (i % 5 == 0)
    {
        ouput += "Buzz";
    }
    Console.WriteLine(ouput == "" ? i : ouput);
}

