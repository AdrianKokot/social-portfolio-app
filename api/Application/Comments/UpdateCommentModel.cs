using System.ComponentModel.DataAnnotations;

namespace Sociussion.Application.Comments;

public class UpdateCommentModel
{
    [MaxLength(1024)]
    [MinLength(10)]
    [Required]
    public string Content { get; set; } = string.Empty;
}