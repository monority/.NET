using System.Collections.Generic;
using System.Data.Common;
using ExerciceLinQ.Classes;
using Person = (int Id, string Name, int Age, string City);

var people = new List<Person>
{
    (1, "Alice", 25, "Paris"),
    (2, "Bob", 30, "Lyon"),
    (3, "Charlie", 35, "Marseille"),
    (4, "Diana", 40, "Paris"),
    (5, "Eve", 28, "Lyon"),
    (6, "Frank", 33, "Paris"),
    // (7, "Daniel", 18, "Paris")
};

Console.WriteLine("---------People over 30------------");
List<Person> PeopleOver30 = people.Where(person => person.Age > 30).ToList();
PeopleOver30.ForEach(person => Console.WriteLine(person.Name));


Console.WriteLine("---------People ordered by Age------------");
List<Person> PeopleOrderByAge = people.OrderBy(person => person.Age).ToList();
PeopleOrderByAge.ForEach(person => Console.WriteLine(person.Name));


Console.WriteLine("---------People in Lyon------------");
// List<Person> PeopleCountInLyon = people.Where(person => person.City == "Lyon").ToList();
// PeopleCountInLyon.ForEach(person => Console.WriteLine(person.Name));
int CountLyon = people.Count(p => p.City == "Lyon");
Console.WriteLine(CountLyon);


Console.WriteLine("---------Oldest People------------");
// Console.WriteLine(people.Max(x => x.Age));
Person OldestPeo = people.OrderByDescending(x => x.Age).First();
Console.WriteLine(OldestPeo.Name);


Console.WriteLine("---------Order by Town------------");
List<String> TownList = people.Select(person => person.City).Distinct().ToList();
TownList.ForEach(town => Console.WriteLine(town));


Console.WriteLine("---------Verify people over 20------------");
bool PeopleOver20 = people.All(person => person.Age > 20);
Console.WriteLine(PeopleOver20 ? "Yes" : "No");


Console.WriteLine("---------Only age and names------------");
List<(string Name, int Age)> NewPeople = people.Select(person => (person.Name, person.Age)).ToList();
NewPeople.ForEach(person => Console.WriteLine(person.Name + " " + person.Age));


Console.WriteLine("---------Youngest people in paris------------");
List<Person> PeopleInParis = people.OrderBy(person => person.City == "Paris").ToList();
PeopleInParis.OrderBy(person => person.Age).FirstOrDefault();


Console.WriteLine("---------Group by town and show only names------------");
var results =  people.GroupBy(p => p.City).Select(people => new { City = people.Key, People = people.Select(p => p.Name) }).ToList();
results.ForEach(result => Console.WriteLine(result.City + " : " + string.Join(", ", result.People)));


Console.WriteLine("---------Infinite sequence of evens------------");

// Enumerable<int> Range = Enumerable.Range (0, int.MaxValue);


Console.WriteLine("---------Pagination------------");


var Numbers = new List<Nbrs>();

for (int i = 1; i <= 100; i++)
{
	Random rdm = new Random();
	int id = i;
	int value = rdm.Next(0,99);
	Numbers.Add(new Nbrs { Id = id, Value = value });

}
int noPage = 3;
int nbElem = 10;
var numberAtPage = Numbers.Skip(nbElem * (noPage - 1))
                                    .Take(nbElem);
numberAtPage.ToList().ForEach(number => Console.WriteLine($"Id: {number.Id}, Value: {number.Value}"));

List<int> Integers = new(){
	1, 2, 3, 4, 5, 6, 7, 8, 9, 10
};
Console.WriteLine(Integers.Max());

List<string> Words = new(){
	"chat",
	"ordinateur",
	"table",
	"lampe",
	"programme"
};

