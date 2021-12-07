﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Sociussion.Data.Models.Discussion
{
    public class Discussion
    {
        public ulong Id { get; set; }

        [MaxLength(255)] public string Title { get; set; }
        public string Content { get; set; }
        
        public ApplicationUser Author { get; set; }
        public string AuthorId { get; set; }

        public Community.Community Community { get; set; }
        public ulong CommunityId { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? EditedAt { get; set; } = null;

        public ulong VotesUp { get; set; } = 0;
        public ulong VotesDown { get; set; } = 0;
    }
}
