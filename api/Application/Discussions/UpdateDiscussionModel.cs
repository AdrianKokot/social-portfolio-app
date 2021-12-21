using System.ComponentModel.DataAnnotations;

namespace Sociussion.Application.Discussions;

public class UpdateDiscussionModel
{
    [Required]
    [MaxLength(255)]
    [MinLength(3)]
    public string Title { get; set; }

    [Required] [MinLength(10)] public string Content { get; set; }
}