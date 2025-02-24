using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ExercicePizza.Models;

public class Ingredients
{
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    [ForeignKey(nameof(Id))]
    public int? PizzaId { get; set; }

}
