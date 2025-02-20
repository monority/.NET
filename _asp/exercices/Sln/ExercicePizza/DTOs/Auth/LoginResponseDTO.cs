using System.ComponentModel.DataAnnotations;
using ContactWithDtos.Models;

namespace ExercicePizza.DTOs.Auth;

public class LoginResponseDTO
{
    public bool IsSuccessful { get; set; }
    public string? ErrorMessage { get; set; }
    public User? User { get; set; }
    public string? Token { get; set; }

}
