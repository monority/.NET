namespace _exercice02.Classes;

internal class Employee
{
    private string? _category { get;  set; }
    private string? _name { get;  set; }
    private int _salary { get;  set; }
    private int? _registration { get;  set; }
    private string? _service { get;  set; }
    private static int TotalEmployee { get;  set; }
    private static float TotalSalary { get; set; }
    public int Salary
    {
        get => _salary;
        set 
        {
            TotalSalary -= _salary;
   
            _salary = value;
      
            TotalSalary += _salary;
        }
    }
    public Employee(string? category, string? name, float salary, int? registration, string? service){
        _category = category;
        _name = name;
        _registration = registration;
        _service = service;
        TotalSalary += _salary;
        TotalEmployee++;
        Salary = _salary;

    }

    public Employee()
    {
        Salary = 16236;
    }

    public void ShowEmployee()
    {
        Console.WriteLine($"Name : '{_name}', salary : '{Salary}' ");
    }
    
    public static void ResetEmployee()
    {
        TotalEmployee = 0;
        TotalSalary = 0;
    }

    public static void ShowTotalEmployee()
    {
        Console.WriteLine($"Total employee : '{TotalEmployee}' ");
    }
    
    public static void ShowTotalSalary()
    {
        Console.WriteLine($"Total Salary : '{TotalSalary}' ");
    }
}