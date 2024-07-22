using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostCentral.Models;

[Table("PostTags")]
public class PostTags
{
    [Required]
    public Guid PostId { get; set; }

    [ForeignKey("PostId")]
    public Post Post { get; set; } = null!;

    [Required]
    public Guid TagId { get; set; }

    [ForeignKey("TagId")]
    public Tag Tag { get; set; } = null!;
}