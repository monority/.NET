namespace _exercice02.Classes;

internal class Employee
{
    private string? _category;
    private string? _name;
    private double? _salary;
    private int? _registration;
    private string? _service;
    private int _totalemployee = 0;
    public Employee(string? category, string? name, double? salary, int? registration, string? service){
        _category = category;
        _name = name;
        _salary = salary;
        _registration = registration;
        _service = service; 
    }
    
    public int TotalEmployee()
    {
        _totalemployee = _totalemployee + 1;
        return _totalemployee;
    }
    
    public void Display()
    {
        Console.WriteLine($"Name : '{_name}', salary : '{_salary}' \n Number total of Employees : {TotalEmployee()}");
        _totalemployee = 0;
    }
}