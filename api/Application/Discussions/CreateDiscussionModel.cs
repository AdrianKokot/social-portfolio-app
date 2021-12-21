using System.ComponentModel.DataAnnotations;
using Sociussion.Application.Comments;

namespace Sociussion.Application.Discussions;

public class CreateDiscussionModel : UpdateCommentModel
{
    [MaxLength(255), Required]
    public string Title { get; set; }

    [Required] public ulong CommunityId { get; set; }
}