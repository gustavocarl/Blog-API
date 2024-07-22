using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostCentral.Models;

[Table("Tags")]
public class Tag : Base
{
    [Required(ErrorMessage = "Tag name is required")]
    [StringLength(50)]
    public string TagName { get; set; } = string.Empty!;

    public ICollection<PostTags> PostTags { get; set; } = [];
}