using System.ComponentModel.DataAnnotations;

namespace Sociussion.Application.Comments;

public class CreateCommentModel : UpdateCommentModel
{
    [Required] public ulong DiscussionId { get; set; }
}