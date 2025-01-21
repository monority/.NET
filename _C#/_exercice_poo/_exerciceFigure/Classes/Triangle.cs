namespace _exerciceFigure.Classes;

public class Triangle : Figure
{
    public double Base;
    public double Hauteur;

    public Triangle(double baseHauteur, double hauteur)
    {
        Base = baseHauteur;
        Hauteur = hauteur;
    }
    public void Deplacer(double x, double y)
    {
        Console.WriteLine($"Deplacement du Triangle par (x: {x}, y: {y})");
    }
    public override string ToString() => $"{Base}, {Hauteur}";

}