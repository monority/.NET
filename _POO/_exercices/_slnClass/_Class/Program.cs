// See https://aka.ms/new-console-template for more information

using System.Security.Principal;
using _DemoClass.Classes;

Dinosaur denver = new Dinosaur();

Console.Write(denver.Age);
denver.Age = 120;

Console.WriteLine(denver.Age);