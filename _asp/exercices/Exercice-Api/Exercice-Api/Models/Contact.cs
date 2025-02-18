using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Exercice_Api.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "First name is required")]
        [StringLength(50)]
        [RegularExpression("^[A-Z].*", ErrorMessage = "First name must start with capital letter.")]

        public required string FirstName { get; set; } = string.Empty;
        [RegularExpression("^[A-Z][a-z]+$", ErrorMessage = "Last name must contain only capital letters.")]
        public required string LastName { get; set;  } = string.Empty;
        public int Age { get; set; }
        public string? FullName { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        [StringLength(1)]
        [RegularExpression("^[FMN]{0,1}$", ErrorMessage = "Must be F | M | N.")]

        public required string Gender { get; set; } = string.Empty;
        [ValidateEmail]
        public string? Email { get; set; }
        [ValidatePhone]
        public string? PhoneNumber { get; set; }
        [Required]
        [BirthDateLimit]
        public DateOnly BirthDate { get; set; }

    }
}
