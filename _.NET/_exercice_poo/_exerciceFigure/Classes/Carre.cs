namespace _exerciceFigure.Classes;

public class Carre : Figure
{
    public double Cote;
    
    public Carre(double cote)
    {
        Cote = cote;
    }

    public new void Deplacer(double x, double y)
    {
        Console.WriteLine($"Deplacement du Carré par (x: {x}, y: {y})");
        Origin = new Point(Origin.PosX + x, Origin.PosY + y);
    }

    public override string ToString() =>
        $"\n A = {Origin.PosX};{Origin.PosY} \n B = {Origin.PosY - Cote};{Origin.PosY} \n C = {Origin.PosY - Cote};{Origin.PosX + Cote} \n D = {Origin.PosX};{Origin.PosX + Cote}";
}