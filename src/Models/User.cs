using Blog_API.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog_API.Models;

[Table("Users")]
public class User : Base
{
    [Required(ErrorMessage = "First name is required")]
    [StringLength(50, MinimumLength = 3)]
    public string FirstName { get; set; } = string.Empty!;

    [Required(ErrorMessage = "Last name is required")]
    [StringLength(50, MinimumLength = 3)]
    public string LastName { get; set; } = string.Empty!;

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress]
    [StringLength(100)]
    public string Email { get; set; } = string.Empty!;

    [Required(ErrorMessage = "Username is required")]
    [StringLength(50, MinimumLength = 3)]
    public string UserName { get; set; } = string.Empty!;

    [Required(ErrorMessage = "Password Hash is required")]
    public string PasswordHash { get; set; } = string.Empty!;

    [Required(ErrorMessage = "Password Salt is required")]
    public string PasswordSalt { get; set; } = string.Empty!;

    [Required]
    public string Role { get; set; } = string.Empty!;

    public ICollection<Post> Posts { get; set; } = new List<Post>();

    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
}