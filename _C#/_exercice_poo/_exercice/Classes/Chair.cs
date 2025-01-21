namespace _exercice.Classes;

internal class Chair
{
    public int _feets = 4;
    public string? _material = "Wood";
    public string? _color = "White";


    public Chair(int feets, string material, string color)
    {
        _feets = feets;
        _material = material;
        _color = color;
    }

    public Chair()
    {
        
    }
    public string Display()
    {
        return $"feets: {_feets}, material: {_material}, color: {_color}";
    }
}