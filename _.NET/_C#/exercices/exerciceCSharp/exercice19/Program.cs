﻿

for (int i = 1; i <= 10; i++)
{
    Console.WriteLine($"Table of {i}");

    for (int j = 0; j < 10; j++)
    {
        Console.WriteLine($"{i} x {j} = {i * j}");
    }
}