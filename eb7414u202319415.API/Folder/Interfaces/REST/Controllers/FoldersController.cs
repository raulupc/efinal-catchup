using System.Net.Mime;
using eb7414u202319415.API.Folder.Application.Internal.CommandServices;
using eb7414u202319415.API.Folder.Interfaces.REST.Resources;
using eb7414u202319415.API.Folder.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace eb7414u202319415.API.Folder.Interfaces.REST.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class FoldersController(FolderCommandService folderCommandService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateFolder([FromBody] CreateFolderResource resource)
    {
        try
        {
            var folder = await folderCommandService.Handle(
                resource.SpaceId,
                resource.Name,
                resource.Description,
                resource.VisibilityType,
                resource.CreatedBy,
                resource.GeneratedAt
            );

            var folderResource = CreateFolderCommandFromResourceAssembler.ToResourceFromEntity(folder);
            
            return CreatedAtAction(nameof(CreateFolder), new { id = folderResource.Id }, folderResource);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}