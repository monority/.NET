using System.ComponentModel.DataAnnotations;
using ExercicePizza.Models;
using ExercicePizza.Utils;
using Microsoft.EntityFrameworkCore;

namespace ExercicePizza.DTOs;

public class PizzaDTO
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Name is required.")]
    [StringLength(30, MinimumLength = 5, ErrorMessage = "Name must be less than {1} characters.")]
    [RegularExpression(@"^[A-Z][A-Za-z\- ]*$", ErrorMessage = "Name must contain only letters and first letter must be in capital")]

    public string Name { get; set; } = string.Empty;
    [Precision(4,2)]
    [Required(ErrorMessage = "Price is required")]
    public decimal Price { get; set; } 

    [Required(ErrorMessage = "Description is required")]
    [StringLength(150, MinimumLength = 5, ErrorMessage = "Description must be less than {1} characters.")]
    public string Description { get; set; }


     public Status Status { get; set; }
    public List<Ingredients> Ingredients { get; set; }

}
