﻿using System.ComponentModel.DataAnnotations;
using Sociussion.Domain.Common;

namespace Sociussion.Domain.Entities;

public class Community : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string PhotoUrl { get; set; } = string.Empty;

    public DateTime? LastActive { get; set; } = null;

    public ApplicationUser Owner { get; set; }
    public int? OwnerId { get; set; }

    public ICollection<ApplicationUser> Members { get; set; }
    public int MemberCount { get; set; }

    public ICollection<Discussion> Discussions { get; set; }
    public int DiscussionCount { get; set; }
}