namespace eb7414u202319415.API.Folder.Interfaces.REST.Resources;

public record CreateFolderResource(
    int SpaceId,
    string Name,
    string Description,
    string VisibilityType,
    string CreatedBy,
    string GeneratedAt
);