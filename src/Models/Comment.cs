using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog_API.Models;

[Table("Comments")]
public class Comment : Base
{
    [Required(ErrorMessage = "Content is required")]
    [StringLength(500)]
    public string Content { get; set; } = string.Empty!;

    public DateTime PublicationDate { get; set; } = DateTime.Now;

    [Required]
    public User User { get; set; } = null!;

    [ForeignKey("UserId")]
    public Guid UserId { get; set; }

    [Required]
    public Post Post { get; set; } = null!;

    [ForeignKey("PostId")]
    public Guid PostId { get; set; }
}