using eb7414u202319415.API.Space.Domain.Repositories;

namespace eb7414u202319415.API.Folder.Application.ACL;

public class SpaceContextFacade(ISpaceRepository spaceRepository) : ISpaceContextFacade
{
    public async Task<bool> ExistsSpaceId(int spaceId)
    {
        return await spaceRepository.ExistsAsync(spaceId);
    }
}