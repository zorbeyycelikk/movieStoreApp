using MediatR;
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
    public async Task<List<ActorResponse>> Get()
    {
        var operation = new GetAllActorQuery();
        var result = await mediator.Send(operation);
        return result.Response ;
    }

    [HttpGet("{id}")]
    public async Task<ActorResponse> Get(int id)
    {
        var operation = new GetActorById(id);
        var result = await mediator.Send(operation);
        return result.Response;
    }
    
    [HttpPost]
    public async Task <String> Create([FromBody] ActorCreateRequest request)
    {
        var operation = new CreateActorCommand(request);
        var result = await mediator.Send(operation);
        return result.Message;
    }
    
    [HttpPut("{id}")]
    public async  Task<String> Put(int id, [FromBody] ActorUpdateRequest request)
    {
        var operation = new UpdateActorCommand(request,id);
        var result = await mediator.Send(operation);
        return result.Message;
    }
    
    [HttpDelete("{id}")]
    public async Task <String> DeleteById(int id)
    {
        var operation = new DeleteActorCommand(id);
        var result = await mediator.Send(operation);
        return result.Message;
    }
}