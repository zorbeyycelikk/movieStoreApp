using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vk.Operations.Cqrs;
using Vk.Schema;

namespace VkApi.Controllers;
[Route("vk/api/v1/[controller]")]
[ApiController]

public class ActorController : ControllerBase
{
    private readonly IMediator mediator;
    
    public ActorController(IMediator mediator)
    {
        this.mediator = mediator;
    }
    
    [HttpGet]
    [Authorize(Roles = "Celik")]
    public async Task<IActionResult> Get()
    {
        var operation = new GetAllActorQuery();
        var result = await mediator.Send(operation);
        return result.Success ? Ok(result.Response) : result.Message == "Error" ? NotFound() : BadRequest();
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Celik")]
    public async Task<IActionResult> Get(int id)
    {
        var operation = new GetActorById(id);
        var result = await mediator.Send(operation);
        return result.Success ? Ok(result.Response) : result.Message == "Error" ? NotFound() : BadRequest();
    }
    
    [HttpPost]
    [Authorize(Roles = "Celik")]
    public async Task<IActionResult> Create([FromBody] ActorCreateRequest request)
    {
        var operation = new CreateActorCommand(request);
        var result = await mediator.Send(operation);
        return result.Success ? Ok(result.Message) : result.Message == "Error" ? NotFound() : BadRequest();
    }
    
    [HttpPut("{id}")]
    [Authorize(Roles = "Celik")]
    public async  Task<IActionResult> Put(int id, [FromBody] ActorUpdateRequest request)
    {
        var operation = new UpdateActorCommand(request,id);
        var result = await mediator.Send(operation);
        return result.Success ? Ok(result.Message) : result.Message == "Error" ? NotFound() : BadRequest();
    }
    
    [HttpDelete("{id}")]
    [Authorize(Roles = "Celik")]
    public async Task<IActionResult> DeleteById(int id)
    {
        var operation = new DeleteActorCommand(id);
        var result = await mediator.Send(operation);
        return result.Success ? Ok(result.Message) : result.Message == "Error" ? NotFound() : BadRequest();
    }
}