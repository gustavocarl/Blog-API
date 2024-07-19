//Not in use yet
using System.ComponentModel.DataAnnotations;

namespace Blog_API.DTOs;

public class CreatePostDto
{
    [Required]
    public Guid UserId { get; set; }

    [Required(ErrorMessage = "The title is required")]
    [StringLength(200)]
    public string Title { get; set; } = string.Empty!;

    [Required(ErrorMessage = "The content is required")]
    public string Content { get; set; } = string.Empty!;

    [Required]
    public DateTime PublicationDate { get; set; } = DateTime.Now;

    [Required]
    public bool IsPublished { get; set; } = true;

    //   [Required]
    // public List<Guid> TagId { get; set; } = [];
}