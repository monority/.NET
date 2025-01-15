namespace _DemoClass.Classes;

internal class Dinosaur
{
    private int _age;
    public int _name;
    public int _height;
    private double _weight;
    public double Weight
    {
        get
        {
            return _weight;
        }
        set
        {
            if (value <= 0)
            {
                Console.WriteLine("Invalid value, default set to 100");
                _weight = 100;
            }
            else
            {
                _weight = value;
            }
        }
    }
    public int Age
    {
        get
        { 
            Console.WriteLine();
            return _age;
        }
        set
        {
            _age = value;
        }
    }
}