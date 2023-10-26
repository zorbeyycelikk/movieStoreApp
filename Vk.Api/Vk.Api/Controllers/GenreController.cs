using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vk.Operations.Cqrs;
using Vk.Schema;

namespace VkApi.Controllers;
[Route("vk/api/v1/[controller]")]
[ApiController]

public class GenreController : ControllerBase
{
    private readonly IMediator mediator;
    
    public GenreController(IMediator mediator)
    {
        this.mediator = mediator;
    }
    
    [HttpGet]
    public async Task<List<GenreResponse>> Get()
    {
        var operation = new GetAllGenreQuery();
        var result = await mediator.Send(operation);
        return result.Response ;
    }

    [HttpGet("{id}")]
    public async Task<GenreResponse> Get(int id)
    {
        var operation = new GetGenreById(id);
        var result = await mediator.Send(operation);
        return result.Response;
    }
    
    [HttpPost]
    public async Task <String> Create([FromBody] GenreCreateRequest request)
    {
        var operation = new CreateGenreCommand(request);
        var result = await mediator.Send(operation);
        return result.Message;
    }
    
    [HttpPut("{id}")]
    public async  Task<String> Put(int id, [FromBody] GenreUpdateRequest request)
    {
        var operation = new UpdateGenreCommand(request,id);
        var result = await mediator.Send(operation);
        return result.Message;
    }
    
    [HttpDelete("{id}")]
    public async Task <String> DeleteById(int id)
    {
        var operation = new DeleteGenreCommand(id);
        var result = await mediator.Send(operation);
        return result.Message;
    }
}