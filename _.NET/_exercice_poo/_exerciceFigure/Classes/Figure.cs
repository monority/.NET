namespace _exerciceFigure.Classes;

public abstract class Figure : IDeplacable
{
    private Point _origin;
    public Point Origin
    {
        get { return _origin; }
        set { _origin = value; }
    }

    public void Deplacer(double x, double y)
    {
        Console.WriteLine($"Deplacer {x}, {y}");
    }
}