using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vk.Operations.Cqrs;
using Vk.Schema;

namespace VkApi.Controllers;
[Route("vk/api/v1/[controller]")]
[ApiController]

public class MovieController : ControllerBase
{
    private readonly IMediator mediator;
    
    public MovieController(IMediator mediator)
    {
        this.mediator = mediator;
    }
    
    [HttpGet]
    [Authorize(Roles = "Celik , customer")]
    public async Task<List<MovieResponse>> Get()
    {
        var operation = new GetAllMovieQuery();
        var result = await mediator.Send(operation);
        return result.Response ;
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Celik , customer")]
    public async Task<MovieResponse> Get(int id)
    {
        var operation = new GetMovieById(id);
        var result = await mediator.Send(operation);
        return result.Response;
    }
    
    [HttpPost]
    [Authorize(Roles = "Celik")]
    public async Task <String> Create([FromBody] MovieCreateRequest request)
    {
        var operation = new CreateMovieCommand(request);
        var result = await mediator.Send(operation);
        return result.Message;
    }
    
    [HttpPut("{id}")]
    [Authorize(Roles = "Celik")]
    public async  Task<String> Put(int id, [FromBody] MovieUpdateRequest request)
    {
        var operation = new UpdateMovieCommand(request,id);
        var result = await mediator.Send(operation);
        return result.Message;
    }
    
    [HttpDelete("{id}")]
    [Authorize(Roles = "Celik")]
    public async Task <String> DeleteById(int id)
    {
        var operation = new DeleteMovieCommand(id);
        var result = await mediator.Send(operation);
        return result.Message;
    }
}