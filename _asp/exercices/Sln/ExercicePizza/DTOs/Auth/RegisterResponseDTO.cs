using System.ComponentModel.DataAnnotations;
using ContactWithDtos.Models;
using ExercicePizza.Validators;

namespace ExercicePizza.DTOs.Auth;

public class RegisterResponseDTO
{
    public bool IsSuccessful { get; set; }
    public string? ErrorMessage { get; set; }
    public User? User { get; set; }
}
