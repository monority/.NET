using System.ComponentModel.DataAnnotations;

namespace ExercicePizza.DTOs
{
    public class UserDTO
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Name must be less than {1} characters.")]
        [RegularExpression(@"^[A-Z][A-Za-z\- ]*$", ErrorMessage = "Name must contain only letters and first letter must be in capital")]
        public string Name { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "Le format de l'email est invalide.")]
        public string? Email { get; set; }
    }
}
