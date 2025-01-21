Console.WriteLine("Type the last salary (€)");
int salary = Convert.ToInt16(Console.ReadLine());
Console.WriteLine("Enter your age : ");
int age = Convert.ToInt16(Console.ReadLine());
Console.WriteLine("Years of seniority : ");
int years = Convert.ToInt16(Console.ReadLine());
int indemnity;

if (years > 1 && years < 10)
{
    indemnity = (salary / 2)  * years;
}
else
{
    indemnity = salary  * years;
}
if (age > 45 && age < 50)
{   
    indemnity += salary * 2;
}
else if (age > 50)
{
    indemnity += salary * 5;
}

Console.WriteLine("Total salary : " + indemnity);