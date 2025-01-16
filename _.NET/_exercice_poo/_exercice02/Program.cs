// See https://aka.ms/new-console-template for more information

using _exercice02.Classes;

Employee Chloe = new Employee("Default", "Chloe", 25000, 2042042, "Informatique");
Employee Stefan = new Employee("Default", "Stefan", 40000, 2042042, "Informatique");
Employee Denis = new Employee("Default", "Denis", 40000, 2042042, "Informatique");

Chloe.ShowEmployee();
Stefan.ShowEmployee();
Chloe.ShowEmployee();

Employee.ShowTotalSalary();
Employee.ShowTotalEmployee();
Console.WriteLine("Remise a 0");
Employee.ResetEmployee();
Employee.ShowTotalEmployee();
Employee.ShowTotalSalary();
