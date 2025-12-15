using eb7414u202319415.API.Space.Domain.Model.ValueObjects;

namespace eb7414u202319415.API.Space.Domain.Repositories;

public interface ISpaceRepository
{
    Task<IEnumerable<eb7414u202319415.API.Space.Domain.Model.Aggregates.Space>> ListAsync();
    Task<eb7414u202319415.API.Space.Domain.Model.Aggregates.Space?> FindByIdAsync(SpaceId id);
    Task<eb7414u202319415.API.Space.Domain.Model.Aggregates.Space?> FindByWorkSpaceIdAsync(int workSpaceId);
    void Update(eb7414u202319415.API.Space.Domain.Model.Aggregates.Space space);
    Task<bool> ExistsAsync(int id);
}