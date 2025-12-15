namespace eb7414u202319415.API.Folder.Domain.Repositories;

public interface IFolderRepository
{
    Task AddAsync(eb7414u202319415.API.Folder.Domain.Model.Aggregates.Folder folder);
    Task<eb7414u202319415.API.Folder.Domain.Model.Aggregates.Folder?> FindByIdAsync(int id);
}