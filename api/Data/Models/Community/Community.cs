using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sociussion.Data.Models.Community
{
    public class Community
    {
        public ulong Id { get; set; }

        [MaxLength(255)] public string Name { get; set; }
        public ulong MembersCount { get; set; }

        public IEnumerable<ApplicationUser> Members { get; set; }
        public IEnumerable<Discussion.Discussion> Discussions { get; set; }
    }
}
