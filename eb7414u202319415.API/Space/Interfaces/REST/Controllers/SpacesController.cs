using System.Net.Mime;
using eb7414u202319415.API.Space.Domain.Repositories;
using eb7414u202319415.API.Space.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace eb7414u202319415.API.Space.Interfaces.REST.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class SpacesController(ISpaceRepository spaceRepository) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllSpaces()
    {
        var spaces = await spaceRepository.ListAsync();
        var resources = spaces.Select(SpaceResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
}