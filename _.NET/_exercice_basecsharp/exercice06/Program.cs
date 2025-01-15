using System;

Console.WriteLine("Enter the value of the first side (in cm)");
double first_side = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("Enter the value of the second side (in cm)");
double second_side = Convert.ToDouble(Console.ReadLine());
double hypothenus = Math.Pow(first_side, 2) + Math.Pow(second_side, 2);
double result = Math.Sqrt(hypothenus);
double total = Math.Round(result, 2);
Console.WriteLine($"Hypothenus is : {total}");