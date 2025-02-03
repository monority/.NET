// See https://aka.ms/new-console-template for more information
using Demo01.Data;
using Demo01.Models;

using var context = new ApplicationDbContext();

var fleursDuMal = new Book()
{
	TItle = "Les fleurs du mal",
	Author = "Charles Baudelaire",
	PublicationDate = new DateTime(1857, 06, 21),
	Description = "Un livre rempli de poèmes",
};


var tchoupi = new Book()
{
	TItle = "Tchoupi à l'école",
	Author = "Auteur pour les enfants",
	PublicationDate = new DateTime(1950, 04, 21),
	Description = "Un livre pour les enfants",
};


// CREATE 
// Préparation de la requête SQL
//context.Books.Add(fleursDuMal); // INSERT INTO
//context.Books.Add(tchoupi); // INSERT INTO
//context.Set<Book>().Add(tchoupi); // INSERT
// à noter qe DbSet<> implémente IQueryable et donc IEnumerable

// exécute les requêtes de NOTIFICATION précédents (CUD -- Create Update Delete)
//context.SaveChanges();

// Read

// Lire un enregistrement

//var result = context.Books.FirstOrDefault(b => b.TItle!.Contains("Tchoupi"));
//Console.WriteLine(result.TItle);
//context.Books.ToList().ForEach(b => Console.WriteLine(b.Author));

// Lire avec l'id 
//result = context.Books.FirstOrDefault(b => b.Id == 3);
//result = context.Books.Find(3); // équilvalent, attention au type utilisé (type de la PK)

// récupérer une liste d'élements avec un filtre
//var oldBooks = context.Books.Where(b => b.PublicationDate < DateTime.Now.AddYears(-50)).ToList();
//var oldBooks = context.Books.Where(b => b.PublicationDate < new DateTime(1900, 1, 1)).ToList();
//oldBooks.ForEach(b => Console.WriteLine($"{b.PublicationDate}"));
//oldBooks.ForEach(b => Console.WriteLine($"{b.PublicationDate:d}"));
//oldBooks.ForEach(b => Console.WriteLine($"{b.PublicationDate:yy-MM-dd}"));

// UPDATE
//var book = context.Books.FirstOrDefault(b => b.Id == 1); // Un object est récupéré et traqué par EFcore
//book.TItle = "Nouveau titre"; // Ses modifications peuvent être appliqués avec un SaveChanges
//context.SaveChanges();

var newReplaceBook = new Book() // Nouvelle instance non traquée
{
	Id=1, // Id de correspondance pour l'Update
	TItle = "Les fleurs du mal 2",
	Author = "Charles v2",
	PublicationDate = new DateTime(2300, 10, 21),
	Description = "Un nouveau livre de dystopie",
};

context.Books.Update(newReplaceBook); // Version moins optimisée, part d'un nouvel objet 
context.SaveChanges();

// Autre approche plus avancée, donnera le même résultat que la première méthode
context.Attach(newReplaceBook); // On le lie à la BDD, l'object devient traqué 
context.Entry(newReplaceBook).Property(p => p.TItle).IsModified = true; // on précise ce qui a été modifié 
context.Entry(newReplaceBook).Property(p => p.Author).IsModified = true;
context.SaveChanges();

// DELETE 

var book = context.Books.Find(2);
context.Books.Remove(book); // Récupération de l'entité obligatoire
context.SaveChanges();