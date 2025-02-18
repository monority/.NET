using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Exercice_Api.Models;

public class Contact
{
    [Key]
    public int Id { get; set; }
    [RegularExpression("^[A-Z][a-z]*$", ErrorMessage = "First name must start with a capital letter and contain only letters.")]
    public required string? FirstName { get; set; }
    [RegularExpression("^[A-Z]+$", ErrorMessage = "Last name must contain only capital letters.")]

    public required string? LastName { get; set;  }
    public int Age
    {
        get
        {
            int age = DateTime.Now.Year - BirthDate.Year;
            if (BirthDate > DateOnly.FromDateTime(DateTime.Now.AddYears(-age))) 
                age--;
            return age;
        }
    }
    public string FullName => $"{FirstName} {LastName}";
    [Required(ErrorMessage = "Gender is required")]
    [StringLength(1)]
    [RegularExpression("^[FMN]{0,1}$", ErrorMessage = "Must be F | M | N.")]
    public required string? Gender { get; set; }
    [EmailAddress(ErrorMessage = "Email format is invalid")]
    public string? Email { get; set; }
    [Phone(ErrorMessage = "Phone number is invalid")]
    public string? PhoneNumber { get; set; }
    [Required]
    [Range(typeof(DateOnly), "1911-01-01", "9999-12-31", ErrorMessage ="Birthdate must be after 1910")]
    public DateOnly BirthDate { get; set; }
}
