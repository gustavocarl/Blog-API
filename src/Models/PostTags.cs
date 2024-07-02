using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog_API.Models
{
    public class PostTags
    {
        [ForeignKey("PostId")]
        public Guid PostId { get; set; }

        [Required]
        public Post Post { get; set; } = null!;

        [ForeignKey("TagId")]
        public Guid TagId { get; set; }

        [Required]
        public Tag Tag { get; set; } = null!;
    }
}
