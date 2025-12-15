namespace eb7414u202319415.API.Folder.Application.ACL;

public interface ISpaceContextFacade
{
    Task<bool> ExistsSpaceId(int spaceId);
}