using System.ComponentModel.DataAnnotations;

namespace Sociussion.Data.Models.Discussion
{
    public class Discussion
    {
        public ulong Id { get; set; }

        [MaxLength(255)] public string Title { get; set; }

        public Community.Community Community { get; set; }
    }
}
