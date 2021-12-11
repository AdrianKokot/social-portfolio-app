using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sociussion.Data.Models.Community
{
    public class Community
    {
        public ulong Id { get; set; }
        [MaxLength(255)] public string Name { get; set; }
        [MaxLength(512)] public string Description { get; set; }
        [MaxLength(512)] public string PhotoUrl { get; set; }


        public ApplicationUser Owner { get; set; }
        public string OwnerId { get; set; }

        public ulong MembersCount { get; set; }

        public ICollection<ApplicationUser> Members { get; set; }

        public ICollection<Discussion.Discussion> Discussions { get; set; }
        
        public ICollection<Comment.Comment> Comments { get; set; }
    }
}
