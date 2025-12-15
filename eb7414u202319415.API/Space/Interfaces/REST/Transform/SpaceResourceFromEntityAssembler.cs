using eb7414u202319415.API.Space.Interfaces.REST.Resources;

namespace eb7414u202319415.API.Space.Interfaces.REST.Transform;

public static class SpaceResourceFromEntityAssembler
{
    public static SpaceResource ToResourceFromEntity(eb7414u202319415.API.Space.Domain.Model.Aggregates.Space entity)
    {
        return new SpaceResource(
            entity.Id,
            entity.WorkSpaceId,
            entity.Name,
            entity.State.ToString(),
            entity.ColorTag
        );
    }
}