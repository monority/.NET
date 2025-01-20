namespace _exerciceFigure.Classes;

public class Rectangle : Figure
{
    public double Longueur;
    public double Largeur;

    public Rectangle(double longueur, double largeur)
    {
        Longueur = longueur;
        Largeur = largeur;
    }

    public void Deplacer(double x, double y)
    {
        Console.WriteLine($"Deplacement du Carre par (x: {x}, y: {y})");
    }

}