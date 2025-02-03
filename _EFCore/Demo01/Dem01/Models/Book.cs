using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Rajouter System.ComponentModel.DataAnnotations pour aller avec la [key]
namespace Demo01.Models
{
    internal class Book
    {   
        // L'id est détecté automatiquement si on l'apelle Id ou <NomEntité>Id
        // [key] a préciser lorsqu'on ne respecte pas la convention
        public int Id { get; set; }
        // [MinLength(5)]
        // [MaxLength(200)]
        [Required, MinLength(5), MaxLength(200)] // Ne pas oublier d'ajouter la migration
	    //public int Matricule => Id; // pas de champ dans la bdd car l'attribut est dupliqué -- pas de colonne dans la table
        public string? TItle { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; } 
        public DateTime PublicationDate { get; set; }
        // public int BookAge => // Calcul de l'âge -- Pas de champ non plus (pas d'élement derrière) 
        // DateTime.Now est à éviter 
    }
}
