using Sociussion.Domain.Abstractions;

namespace Sociussion.Domain.Common;

public abstract class BaseEntity : IBaseEntity
{
    public ulong Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; } = null;
}