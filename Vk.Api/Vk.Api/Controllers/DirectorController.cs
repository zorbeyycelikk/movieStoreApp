using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vk.Operations.Cqrs;
using Vk.Schema;

namespace VkApi.Controllers;
[Route("vk/api/v1/[controller]")]
[ApiController]

public class DirectorController : ControllerBase
{
    private readonly IMediator mediator;
    
    public DirectorController(IMediator mediator)
    {
        this.mediator = mediator;
    }
    
    [HttpGet]
    [Authorize(Roles = "Celik, customer")]
    public async Task<List<DirectorResponse>> Get()
    {
        var operation = new GetAllDirectorQuery();
        var result = await mediator.Send(operation);
        return result.Response ;
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Celik, customer")]
    public async Task<DirectorResponse> Get(int id)
    {
        var operation = new GetDirectorById(id);
        var result = await mediator.Send(operation);
        return result.Response;
    }
    
    [HttpPost]
    [Authorize(Roles = "Celik")]
    public async Task <String> Create([FromBody] DirectorCreateRequest request)
    {
        var operation = new CreateDirectorCommand(request);
        var result = await mediator.Send(operation);
        return result.Message;
    }
    
    [HttpPut("{id}")]
    [Authorize(Roles = "Celik")]
    public async  Task<String> Put(int id, [FromBody] DirectorUpdateRequest request)
    {
        var operation = new UpdateDirectorCommand(request,id);
        var result = await mediator.Send(operation);
        return result.Message;
    }
    
    [HttpDelete("{id}")]
    [Authorize(Roles = "Celik")]
    public async Task <String> DeleteById(int id)
    {
        var operation = new DeleteDirectorCommand(id);
        var result = await mediator.Send(operation);
        return result.Message;
    }
}