using eb7414u202319415.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using eb7414u202319415.API.Space.Domain.Model.ValueObjects;
using eb7414u202319415.API.Space.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace eb7414u202319415.API.Space.Infrastructure.Persistence.EFC.Repositories;

public class SpaceRepository(AppDbContext context) : ISpaceRepository
{
    public async Task<IEnumerable<eb7414u202319415.API.Space.Domain.Model.Aggregates.Space>> ListAsync()
    {
        return await context.Set<eb7414u202319415.API.Space.Domain.Model.Aggregates.Space>().ToListAsync();
    }

    public async Task<eb7414u202319415.API.Space.Domain.Model.Aggregates.Space?> FindByIdAsync(SpaceId id)
    {
        return await context.Set<eb7414u202319415.API.Space.Domain.Model.Aggregates.Space>().FirstOrDefaultAsync(s => s.Id == id.Id);
    }

    public async Task<eb7414u202319415.API.Space.Domain.Model.Aggregates.Space?> FindByWorkSpaceIdAsync(int workSpaceId)
    {
        return await context.Set<eb7414u202319415.API.Space.Domain.Model.Aggregates.Space>().FirstOrDefaultAsync(s => s.WorkSpaceId == workSpaceId);
    }

    public void Update(eb7414u202319415.API.Space.Domain.Model.Aggregates.Space space)
    {
        context.Set<eb7414u202319415.API.Space.Domain.Model.Aggregates.Space>().Update(space);
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await context.Set<eb7414u202319415.API.Space.Domain.Model.Aggregates.Space>().AnyAsync(s => s.Id == id);
    }
}