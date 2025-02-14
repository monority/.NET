using System.ComponentModel.DataAnnotations;

namespace Exercice06.Models
{
    public class MovieCreateViewModel
    {
        [StringLength(100)]
        public required string Title { get; set; }
        public required string Director { get; set; }
        public int Duration { get; set; }
        public Status Status { get; set; }  
        public string PictureUrl   { get; set; }
        public required IFormFile Picture { get; set; }
    }
}
