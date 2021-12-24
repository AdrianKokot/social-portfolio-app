using System.ComponentModel.DataAnnotations;

namespace Sociussion.Application.Comments;

public class CreateCommentModel : UpdateCommentModel
{
    [Required] public int DiscussionId { get; set; }
}