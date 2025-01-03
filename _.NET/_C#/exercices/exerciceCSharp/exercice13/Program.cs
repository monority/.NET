Console.WriteLine("Enter your size");
int size = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Enter your weight");
int weight = Convert.ToInt32(Console.ReadLine());

if ((weight >= 43 && weight <= 47 && size >= 145 && size <= 169) ||
    (weight >= 48 && weight <= 53 && size >= 145 && size <= 166) ||
    (weight >= 54 && weight <= 59 && size >= 145 && size <= 163) ||
    (weight >= 60 && weight <= 65 && size >= 145 && size <= 160))
{
    Console.WriteLine("size 1");
}
else if ((weight >= 48 && weight <= 53 && size >= 169 && size <= 178) ||
    (weight >= 54 && weight <= 59 && size >= 166 && size <= 175) ||
    (weight >= 60 && weight <= 65 && size >= 163 && size <= 172) ||
    (weight >= 66 && weight <= 71 && size >= 160 && size <= 169))
{
    Console.WriteLine("size 2");
}
else if ((weight >= 54 && weight <= 59 && size >= 178 && size <= 183) ||
    (weight >= 60 && weight <= 65 && size >= 175 && size <= 183) ||
    (weight >= 66 && weight <= 71 && size >= 172 && size <= 183) ||
    (weight >= 72 && weight <= 77 && size >= 163 && size <= 183))
{
    Console.WriteLine("size 3");
}
else
{
    Console.WriteLine("Size doesn't exist");
}

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