using System.ComponentModel.DataAnnotations;

namespace Sociussion.Data.Models.Comment
{
    public class CreateCommentModel
    {
        [MaxLength(1024)]
        [MinLength(10)]
        [Required]
        public string Content { get; set; }

        [Required] public ulong DiscussionId { get; set; }
    }
}
