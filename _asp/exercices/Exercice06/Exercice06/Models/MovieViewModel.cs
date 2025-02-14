using System.ComponentModel.DataAnnotations;

namespace Exercice06.Models;

public class MovieViewModel
{
    [Key]
    public long Id { get; init; }
    public required string PictureUrl { get; set; }
    public required string Title { get; set; }
    public string Director { get; set; }

    public int Duration { get; set; }
    public Status Status { get; set; }
    public record MovieModelViewRecord(
            long Id,
            string PictureUrl,
            string Title,
            string Director,
            int Duration,
            Status status
        )
    { }
}
