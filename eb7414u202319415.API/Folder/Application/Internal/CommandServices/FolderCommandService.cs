using eb7414u202319415.API.Folder.Application.ACL;
using eb7414u202319415.API.Folder.Domain.Model.Events;
using eb7414u202319415.API.Folder.Domain.Repositories;
using eb7414u202319415.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using eb7414u202319415.API.Space.Domain.Repositories; // Necesario para la lógica del evento (simulado en monolito)

namespace eb7414u202319415.API.Folder.Application.Internal.CommandServices;

public class FolderCommandService(
    IFolderRepository folderRepository,
    ISpaceContextFacade spaceContextFacade,
    ISpaceRepository spaceRepository, // Inyectamos repo del otro contexto para manejar el evento sincrónicamente
    AppDbContext unitOfWork)
{
    public async Task<eb7414u202319415.API.Folder.Domain.Model.Aggregates.Folder> Handle(
        int spaceId, 
        string name, 
        string description, 
        string visibilityType, 
        string createdBy, 
        string generatedAt)
    {
        //[cite_start]// 1. ACL Validation [cite: 42]
        if (!await spaceContextFacade.ExistsSpaceId(spaceId))
        {
            throw new Exception($"Space with Id {spaceId} not found.");
        }

        // 2. Parse Data
        var visibilityEnum = Enum.Parse<eb7414u202319415.API.Folder.Domain.Model.ValueObjects.EVisibilityType>(visibilityType);
        var dateGenerated = DateTime.Parse(generatedAt);

        // 3. Create Aggregate
        var folder = new eb7414u202319415.API.Folder.Domain.Model.Aggregates.Folder(
            spaceId,
            name,
            description,
            visibilityEnum,
            new eb7414u202319415.API.Folder.Domain.Model.ValueObjects.CreatedBy(createdBy),
            dateGenerated
        );

        // 4. Persist
        await folderRepository.AddAsync(folder);
        await unitOfWork.SaveChangesAsync();

        //[cite_start]// 5. Integration Event Logic [cite: 43, 45]
        // "Event Handler... debe actualizar el valor de name para el space referenciado"
        // Al estar en un monolito sin Bus externo configurado, ejecutamos la lógica del Handler aquí directamente.
        var space = await spaceRepository.FindByIdAsync(new API.Space.Domain.Model.ValueObjects.SpaceId(spaceId));
        if (space != null && space.Name != name)
        {
            space.UpdateName(name);
            spaceRepository.Update(space);
            await unitOfWork.SaveChangesAsync();
        }

        return folder;
    }
}