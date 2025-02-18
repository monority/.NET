using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Exercice_Api.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [CapitalizeFirstLetter]
        public required string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        [UpperCase]
        public required string LastName { get; set; }
        public int Age { get; set; }
        public string? FullName { get; set; }
        [Required]
        [StringLength(1)]
        [LimitToCharacters]
        public required string Gender { get; set; }
        [ValidateEmail]
        public string? Email { get; set; }
        [ValidatePhone]
        public string? PhoneNumber { get; set; }
        [Required]
        [BirthDateLimit]
        public DateOnly BirthDate { get; set; }

    }
}
