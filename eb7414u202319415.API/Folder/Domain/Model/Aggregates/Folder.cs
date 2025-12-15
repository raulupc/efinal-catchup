using eb7414u202319415.API.Folder.Domain.Model.ValueObjects;
using eb7414u202319415.API.Shared.Domain.Model.Aggregate;

namespace eb7414u202319415.API.Folder.Domain.Model.Aggregates;

public class Folder : AuditableEntity
{
    public int Id { get; set; }
    public int SpaceId { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public EVisibilityType VisibilityType { get; private set; }
    public CreatedBy CreatedBy { get; private set; }
    public DateTime GeneratedAt { get; private set; }

    public Folder()
    {
        Name = string.Empty;
        Description = string.Empty;
        CreatedBy = new CreatedBy();
    }

    public Folder(int spaceId, string name, string description, EVisibilityType visibilityType, CreatedBy createdBy, DateTime generatedAt)
    {
        if (generatedAt > DateTime.Now)
        {
            throw new ArgumentException("GeneratedAt cannot be in the future.");
        }

        SpaceId = spaceId;
        Name = name;
        Description = description;
        VisibilityType = visibilityType;
        CreatedBy = createdBy;
        GeneratedAt = generatedAt;
    }
}