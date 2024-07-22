//Not in use yet
using System.ComponentModel.DataAnnotations;

namespace PostCentral.DTOs;

public class CreateCommentDto
{
    [Required(ErrorMessage = "Content is required")]
    [StringLength(500)]
    public string Content { get; set; } = string.Empty!;

    [Required]
    public DateTime PublicationDate { get; set; } = DateTime.Now;

    public Guid UserId { get; set; }

    public Guid PostId { get; set; }
}