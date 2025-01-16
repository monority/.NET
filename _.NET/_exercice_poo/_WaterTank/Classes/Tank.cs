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
        Citern = citern;
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
        if (FillLevel == TotalCapacity)
        {
            Console.WriteLine("Water tank is full");
        }
        else if (FillLevel + water > TotalCapacity)
        {
            var value = FillLevel + water;
            value -= TotalCapacity;
            FillLevel = TotalCapacity;
            Console.WriteLine($"You've got back {value} in Citern {Citern}.");
            TotalWater += FillLevel;
        }
        else
        {
            FillLevel += water;
            TotalWater += water;
        }
        return $"Water quantity in Citern {Citern} after adding {water} liter {FillLevel} / {TotalCapacity}";
    }

    public string RemovingWater(int water)
    {
        int BackWater = 0;
        if (FillLevel == 0)
        {
            Console.WriteLine("Water tank is empty");
        }
       else if (FillLevel - water < 0)
        {
            BackWater = water - FillLevel;
            var value = water - BackWater;
            TotalWater -= value;
            FillLevel = 0;
            Console.WriteLine($"You've got back {BackWater}");
        }
        else
        {
            FillLevel -= water;
            TotalWater -= water;
        }
        return $"Water quantity in Citern {Citern} after removing {water} liter {FillLevel} / {TotalCapacity}";

    }


}

