using System.ComponentModel.DataAnnotations;

namespace Exercice06.Models
{
    public class Movie
    {
    [Key]
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Director { get; set; }

    public int Duration { get; set; }
    public Status Status { get; set; }
    }
}
