using System.Runtime.CompilerServices;

namespace _exerciceWateTank.Classes;

internal class WaterTank
{
    public float Weight { get; set; } = 0;
    public float FillLevel { get; set; } = 10;
    public int TotalCapacity { get; set; }
    private int _citern { get; set; }
    public static float TotalWater = 0;
    public int Citern
    {
        get => _citern;
        set 
        {
          
            _citern = value;
            TotalCitern += _citern;
        }
    }
    public static int TotalCitern {get; set; }
    public WaterTank(float weight, int totalWeight , int citern)
    {
        Weight = weight;
        TotalCapacity = totalWeight;
        _citern = citern;
        TotalWater += FillLevel;
    }

    public string GetWeight()
    {
        return $"Poids total de la citerne {Citern}: {Weight.ToString()}";  
        
        
    }
    public string GetFillLevel()
    {

        return $"Quantité d'eau de la citerne {Citern}: {FillLevel.ToString()} / {TotalCapacity.ToString()}";    

    }

    public float FillWater(int water)
    {
        FillLevel += water;
 
        Console.WriteLine($"You've added {water} to {TotalCapacity} max to citern {Citern}.");
        if (FillLevel >= TotalCapacity)
        {
            TotalWater += TotalCapacity;
            Console.Write($"You've got {FillLevel - TotalCapacity} back\n");
            FillLevel = TotalCapacity;
        }
        return water;
    }

    public static void TotalOfWater()
    {
        Console.WriteLine($"Total Water of all citern : {TotalWater}");
    }
    public string EmptyWater(float water)
    {
        Console.WriteLine($"You've removed {water} liter to actual fill level : {FillLevel} of citern {Citern}");
        var value = FillLevel -= water;
        value = -value;
        if (FillLevel <= 0)
        {
            TotalWater -= TotalCapacity;
            FillLevel = 0;
            Console.WriteLine($"You've got {value} liter back");
        }
        else
        {
            TotalWater -= water;
        }

        return $" Citern {Citern} is empty {FillLevel} / {TotalCapacity} max";
    }
    
}