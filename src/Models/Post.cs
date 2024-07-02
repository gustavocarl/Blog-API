using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog_API.Models;

[Table("Posts")]
public class Post : Base
{
    [Required]
    public Guid UserId { get; set; }

    [ForeignKey("UserId")]
    public User? User { get; set; } = null;

    [Required(ErrorMessage = "Title is required")]
    [StringLength(200)]
    public string Title { get; set; } = string.Empty!;

    [Required(ErrorMessage = "Content is required")]
    public string Content { get; set; } = string.Empty!;

    public DateTime PublicationDate { get; set; } = DateTime.Now;

    public bool IsPublished { get; set; } = true;

    public ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public ICollection<PostTags> PostTags { get; set; } = new List<PostTags>();

}
