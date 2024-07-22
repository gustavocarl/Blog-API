using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostCentral.Models;

[Table("Comments")]
public class Comment : Base
{
    [Required(ErrorMessage = "Content is required")]
    [StringLength(500)]
    public string Content { get; set; } = string.Empty!;

    public DateTime PublicationDate { get; set; } = DateTime.Now;

    [Required]
    public Guid UserId { get; set; }

    [ForeignKey("UserId")]
    public User? User { get; set; }

    [Required]
    public Guid PostId { get; set; }

    [ForeignKey("PostId")]
    public Post? Post { get; set; }
}