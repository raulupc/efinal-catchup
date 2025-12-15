using eb7414u202319415.API.Shared.Domain.Model.Entities;

namespace eb7414u202319415.API.Shared.Domain.Model.Aggregate;

public abstract class AuditableEntity : IEntity
{
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}