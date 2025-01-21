// See https://aka.ms/new-console-template for more information

using _exercice.Classes;

Chair chair01 = new Chair();
Console.WriteLine(chair01.Display());
Chair chair02 = new Chair(6,"Metal", "White");
Console.WriteLine(chair02.Display());