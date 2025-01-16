using _WaterTank.Classes;
Tank water01 = new Tank(20, 20, 10,1 );
Tank water02 = new Tank(15, 20, 10,2);
Console.WriteLine("------------------");
Console.WriteLine(water01.GetFillLevel());
Console.WriteLine(water02.GetFillLevel());

Console.WriteLine("------------------");
Console.WriteLine(water01.GetTotalWeight());
Console.WriteLine(water02.GetTotalWeight());
Console.WriteLine("------------------");
Console.WriteLine(Tank.GetTotalWater());
Console.WriteLine("------------------");
Console.WriteLine(water02.AddingWater(22));
Console.WriteLine("------------------");
Console.WriteLine(Tank.GetTotalWater());