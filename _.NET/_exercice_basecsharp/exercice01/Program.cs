using System.ComponentModel;

Console.WriteLine("*** Ma liste de todo ***");
Console.WriteLine("Aujourd'hui je dois faire:\n" +
    "   - Apprendre le C# \n" +
    "   - Apprendre à utiliser Visual Studio\n" +
    "   - Comprendre l'affichage \"Console\"\n" +
    "   - Créer mon répetoire C:\\MesExercices\\\" pour les ranger \n"+
    "   - Apprécier les fonctionnalités du C#");


// Déclaration et initlisation d'une variable : 

int integer = 42; // valeur par défaut : 0
double real = 3.14; // valeur par défaut : 0
decimal accurate = 3.333333M; // Le decimal est le plus précis dans les calculs // valeur par défaut : 0
char character = 'A'; // valeur par défaut : \0
string text = "Bonjour"; // valeur par défaut ""
bool trueorfalse = true; // valeur par défaut : false
const double Pi = 3.1415926; // valeur fixé non modifiable
int? age; // Démarre sa valeur a "null"

Console.WriteLine("Entier : " + integer);
Console.WriteLine($"Entier {integer}");
Console.Write("Please write your name : ");
string name = Console.ReadLine();
Console.WriteLine($"Your name is {name}");

int c = 0;
Console.WriteLine(++c);

c = c + 1;
c += 10;

Console.WriteLine(Math.Round(Pi));

int compte = 300;

if (compte >= 0)
    Console.WriteLine("Votre compte est créditeur");
else
    Console.WriteLine("Votre compte est débiteur");