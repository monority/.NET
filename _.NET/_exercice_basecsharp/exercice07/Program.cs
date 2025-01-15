using System.Net.Http.Headers;

Console.WriteLine("Enter the price of the product : ");
double product_price = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("Enter the TVA value (%) : ");
double TVA = Convert.ToDouble(Console.ReadLine());
double product_TVA = product_price * TVA / 100;
double product_totalprice = product_price + product_TVA;
Console.WriteLine($"TVA Value is  : {product_totalprice}, product price : {product_TVA}");