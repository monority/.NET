using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ExercicePizza.Utils;

namespace ExercicePizza.Models;

public class Pizza
{
    [Column("id")]
    [Key]
    public int Id { get; set; }
    [Column("name")]

    public string? Name { get; set; }
    [Column("price")]

    public decimal Price { get; set; }
    [Column("description")]
    public string? Description { get; set; }
    [Column("status")]
    public Status Status { get; set; }
    [Column("ingredients")]
    public List<Ingredients>? Ingredients { get; set; } = [];


}
