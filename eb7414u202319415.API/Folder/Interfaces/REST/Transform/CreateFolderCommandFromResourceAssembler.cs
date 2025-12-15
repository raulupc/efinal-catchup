using eb7414u202319415.API.Folder.Domain.Model.Aggregates;
using eb7414u202319415.API.Folder.Interfaces.REST.Resources;

namespace eb7414u202319415.API.Folder.Interfaces.REST.Transform;

public static class CreateFolderCommandFromResourceAssembler
{
    public static FolderResource ToResourceFromEntity(eb7414u202319415.API.Folder.Domain.Model.Aggregates.Folder entity)
    {
        return new FolderResource(
            entity.Id,
            entity.SpaceId,
            entity.Name,
            entity.Description,
            entity.VisibilityType.ToString(),
            entity.CreatedBy.Value,
            entity.GeneratedAt.ToString("yyyy-MM-dd HH:mm:ss")
        );
    }
}