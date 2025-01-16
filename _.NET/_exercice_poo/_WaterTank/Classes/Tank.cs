namespace _WaterTank.Classes;

internal class Tank
{
    public int TotalWeight { get; private set; }
    public int TotalCapacity { get; private set; }
    public static int TotalWater { get; private set; }
    public static int TotalTank { get; private set; }
    public int FillLevel { get; set; }
    public int _citern { get; private set; }

    public int Citern
    {
        get => _citern;
        set
        {

            _citern = value;
            TotalTank += _citern;
        }
    }

    public Tank(int weight, int totalCapacity, int fillLevel, int citern)
    {
        TotalWeight = weight;
        TotalCapacity = totalCapacity;
        _citern = citern;
        FillLevel = fillLevel;
        TotalWater += FillLevel;
    }

    public string GetFillLevel()
    {

        return $"Amount of water in Citern {Citern}: {FillLevel.ToString()} / {TotalCapacity.ToString()}";    

    }

    public string GetTotalWeight()
    {
        return $"Total Weight of Citern {Citern}: {TotalWeight.ToString()}";
    }

    public static string GetTotalWater()
    {
        return $"Total Water is {TotalWater}";
    }

    public string AddingWater(int water)
    {
        if (FillLevel + water > TotalCapacity)
        {
            var value = TotalCapacity + (water - FillLevel);
            Console.WriteLine($"You've got back {value}");
        }
        else
        {
            TotalWater += water;
        }
        return $"Water quantity in Citern {Citern} after adding {water} liter {TotalCapacity} / {TotalCapacity}";
    }


}

