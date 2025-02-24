using System.ComponentModel.DataAnnotations;

namespace ExercicePizza.DTOs;

public class IngredientsDTO
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Name is required.")]

    public string Name { get; set; } = string.Empty;
}
