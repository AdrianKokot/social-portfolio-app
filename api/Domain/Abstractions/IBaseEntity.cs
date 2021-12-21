namespace Sociussion.Domain.Abstractions;

public interface IBaseEntity
{
    ulong Id { get; set; }
    DateTime CreatedAt { get; set; }
    DateTime? UpdatedAt { get; set; }
}