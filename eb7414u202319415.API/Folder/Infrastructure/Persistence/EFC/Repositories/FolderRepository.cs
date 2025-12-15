using eb7414u202319415.API.Folder.Domain.Repositories;
using eb7414u202319415.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using Microsoft.EntityFrameworkCore;

namespace eb7414u202319415.API.Folder.Infrastructure.Persistence.EFC.Repositories;

public class FolderRepository(AppDbContext context) : IFolderRepository
{
    public async Task AddAsync(eb7414u202319415.API.Folder.Domain.Model.Aggregates.Folder folder)
    {
        await context.Set<eb7414u202319415.API.Folder.Domain.Model.Aggregates.Folder>().AddAsync(folder);
    }

    public async Task<eb7414u202319415.API.Folder.Domain.Model.Aggregates.Folder?> FindByIdAsync(int id)
    {
        return await context.Set<eb7414u202319415.API.Folder.Domain.Model.Aggregates.Folder>()
            .FirstOrDefaultAsync(f => f.Id == id);
    }
}