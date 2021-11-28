using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Sociussion.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(64)] public string Name { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Community.Community> OwnedCommunities { get; set; }
        public ICollection<Community.Community> MemberOfCommunities { get; set; }
    }
}
