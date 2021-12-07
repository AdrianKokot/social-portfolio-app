using System.ComponentModel.DataAnnotations;

namespace Sociussion.Data.Models.Discussion
{
    public class CreateDiscussionModel
    {
        [Required] [MaxLength(255)] [MinLength(3)] public string Title { get; set; }
        [Required] public ulong CommunityId { get; set; }
        [Required] [MinLength(10)] public string Content { get; set; }

    }
}
