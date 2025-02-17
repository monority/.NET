using System.ComponentModel.DataAnnotations;

namespace Exercice_Api.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Firstname { get; set; }
        [Required]
        [StringLength(50)]
        public string Lastname { get; set; }
        [MaxLength(3)]
        public int Age { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
