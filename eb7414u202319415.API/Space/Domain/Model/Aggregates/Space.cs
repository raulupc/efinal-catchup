using eb7414u202319415.API.Shared.Domain.Model.Aggregate;
using eb7414u202319415.API.Space.Domain.Model.ValueObjects;

namespace eb7414u202319415.API.Space.Domain.Model.Aggregates;

public class Space : AuditableEntity
{
    public int Id { get; set; }
    public int WorkSpaceId { get; private set; }
    public string Name { get; set; }
    public EState State { get; private set; }
    public string ColorTag { get; private set; }

    public Space()
    {
        Name = string.Empty;
        ColorTag = string.Empty;
    }

    public Space(int workSpaceId, string name, EState state, string colorTag)
    {
        WorkSpaceId = workSpaceId;
        Name = name;
        State = state;
        ColorTag = colorTag;
    }

    public void UpdateName(string name)
    {
        Name = name;
    }
}