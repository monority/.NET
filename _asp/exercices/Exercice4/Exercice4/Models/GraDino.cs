using System.ComponentModel.DataAnnotations;

namespace Exercice4.Models
{
    public class GraDino
    {
        [Key]
        public long Id { get; set; }
       
        [Required]
        [Display(Name = "Nickname")]
        public string NickName { get; set; } = "Razor";
        public int weight { get; set; }
        public int height { get; set; }
        public string specy { get; set; }
    }
   
}
