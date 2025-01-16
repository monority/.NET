using _WaterTank.Classes;
Tank water01 = new Tank(20, 40, 0,1 );
Tank water02 = new Tank(15, 40, 20,2);
Console.WriteLine("------------------");
Console.WriteLine(water01.GetFillLevel());
Console.WriteLine(water02.GetFillLevel());

Console.WriteLine("------------------");
Console.WriteLine(water01.GetTotalWeight());
Console.WriteLine(water02.GetTotalWeight());
Console.WriteLine("------------------");
Console.WriteLine(Tank.GetTotalWater());
Console.WriteLine("------------------");
Console.WriteLine(water02.AddingWater(12));
Console.WriteLine(water01.AddingWater(45));

Console.WriteLine(water01.GetFillLevel());
Console.WriteLine(water02.GetFillLevel());
Console.WriteLine("------------------");
Console.WriteLine(Tank.GetTotalWater());
Console.WriteLine("------------------");
Console.WriteLine(water01.RemovingWater(32));
Console.WriteLine(water02.RemovingWater(5));

Console.WriteLine("------------------");
Console.WriteLine(water01.GetFillLevel());
Console.WriteLine(water02.GetFillLevel());
Console.WriteLine(Tank.GetTotalWater());
Console.WriteLine("-----------------");

