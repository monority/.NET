using System.ComponentModel.DataAnnotations;
using ContactWithDtos.Models;
using ExercicePizza.Validators;

namespace ExercicePizza.DTOs.Auth;

public class RegisterRequestDTO
{
    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Email is invalid")]
    public string? Email { get; set; }
    [DataType(DataType.Password)]
    [PasswordValidator]
    public string? Password { get; set; }
    [Required(ErrorMessage ="Name is required")]
    public string? Name { get; set; }
    public bool IsAdmin { get; set; } = false;
}
