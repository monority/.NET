using _exerciceWateTank.Classes;


WaterTank water01 = new WaterTank(20, 20, 1);
WaterTank water02 = new WaterTank(15, 20, 2);
Console.WriteLine("--------------------------------");

Console.WriteLine(water01.GetFillLevel());
Console.WriteLine(water02.GetFillLevel());
WaterTank.TotalOfWater();
Console.WriteLine("--------------------------------");
water01.FillWater(30);
Console.WriteLine(water01.GetFillLevel());  
Console.WriteLine("--------------------------------");
Console.WriteLine(water01.GetFillLevel());
Console.WriteLine(water02.GetFillLevel());
Console.WriteLine("--------------------------------");
Console.WriteLine(water01.EmptyWater(50));
Console.WriteLine("--------------------------------");
Console.WriteLine(water01.GetFillLevel());
Console.WriteLine(water02.GetFillLevel());
WaterTank.TotalOfWater();