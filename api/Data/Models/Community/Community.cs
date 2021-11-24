using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sociussion.Data.Models.Community
{
    public class Community
    {
        [Key] public string Id { get; init; }

        [MaxLength(255)] public string Name { get; set; }
        public ulong MembersCount { get; set; }

        public IEnumerable<ApplicationUser> Members { get; set; }

        public Community()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
