Console.WriteLine("Enter a value for the square : ");
decimal length = Convert.ToDecimal(Console.ReadLine());
decimal perimeter = length * 4;
decimal area = length * length;
Console.WriteLine($"Perimeter is {perimeter} and area is : {area}");

Console.WriteLine("Enter the length for the rectangle : ");
decimal length_rectangle =  Convert.ToDecimal(Console.ReadLine());
Console.WriteLine("Enter the width for the rectangle : ");
decimal width_rectangle = Convert.ToDecimal(Console.ReadLine());
decimal perimeter_rectangle = (length_rectangle + width_rectangle) * 2;
decimal area_rectangle = length_rectangle * width_rectangle;
Console.WriteLine($"Perimeter is {perimeter_rectangle} and area is : {area_rectangle}");



Console.WriteLine("Enter the value of the first side (in cm)");
double first_side = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("Enter the value of the seco vnd side (in cm)");
double second_side = Convert.ToDouble(Console.ReadLine());
double hypothenus = Math.Pow(first_side, 2) + Math.Pow(second_side, 2);
double result = Math.Sqrt(hypothenus);
double total = Math.Round(result, 2);
Console.WriteLine($"Hypothenus is : {total}");

Console.WriteLine("Enter the price of the product : ");
double product_price = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("Enter the TVA value (%) : ");
double TVA = Convert.ToDouble(Console.ReadLine());
double product_TVA = product_price * TVA / 100;
double product_totalprice = product_price + product_TVA;
Console.WriteLine($"TVA Value is  : {product_totalprice}, product price : {product_TVA}");

Console.WriteLine("Enter your capital value : ");
double capital = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("Rate value (%) : ");
double rate = Convert.ToDouble(Console.ReadLine()) / 100;
Console.WriteLine("Enter the years of save (in years) : ");
double years = Convert.ToDouble(Console.ReadLine());
double new_capital = capital * Math.Pow(rate + 1, years);
double total_capital = new_capital + capital;
Console.WriteLine($"Value of gain will be : {new_capital} after {years} years ");
Console.WriteLine($"Capital final : {total_capital}");