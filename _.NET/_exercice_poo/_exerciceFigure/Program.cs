// See https://aka.ms/new-console-template for more information

using _exerciceFigure.Classes;

Carre carre01 = new Carre(2);
Rectangle rectangle01 = new Rectangle(3, 5);
Console.WriteLine(carre01.ToString());
carre01.Deplacer(1,5);
Console.WriteLine(carre01.ToString());
Console.WriteLine(rectangle01.ToString());