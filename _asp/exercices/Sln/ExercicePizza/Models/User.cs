using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ContactWithDtos.Models;

[Table("users")]
public class User
{
    [Column("id")]
    public Guid Id { get; set; } = Guid.NewGuid();
    [Column("email")]
    public string? Email { get; set; }
    [Column("password")]
    [JsonIgnore]
    public string? Password { get; set; }
    [Column("is_admin")]
    public bool IsAdmin { get; set; } = false;
}
