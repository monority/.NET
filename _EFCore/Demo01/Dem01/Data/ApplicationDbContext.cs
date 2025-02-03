using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo01.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo01.Data
{
// Le DbContext nous permet de communiquer entre nos modèles et la base de données
    internal class ApplicationDbContext : DbContext
    {
		// Dans une app qui n'utilise pas d'injection de dépendances, on utilisera ce constructeur
		public ApplicationDbContext() : base()
		{

		}
		// Les propriétés de type DbSet<Entité> permettent de définir les tables que nous allons utiliser
		public DbSet<Book> Books { get; set; }

		// Méthode appelée lors de la configuration de EFCore à notre application.
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			// ici on utilise une méthode de optionBuilder pour lui spécifier que nous allons utiliser une base de données SQLServer avec la chaîne de connexion
			optionsBuilder.UseSqlServer(@"Data Source=(localdb)\EFCore;Integrated Security=True");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
		// ici, on pourra modifier la BDD avec la FluentAPI d'EFCORE
		// DATA, SED => Données de base de l'application
		modelBuilder.Entity<Book>().HasData(new Book() {  Id = 1, TItle = "La recette des crêpes",  Author = "Arthur DENNETIERE", PublicationDate = DateTime.Now , Description = "La meilleure recette de crêpes"});
		// à noter, l'id est obligatoire
		// Sert pour créer les données en amont, par défaut de notre application
		// DateTime.Now est à éviter, changera la valeur a chaque migration
		}


	}
}
