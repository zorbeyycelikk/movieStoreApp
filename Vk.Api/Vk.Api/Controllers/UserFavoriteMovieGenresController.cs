using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vk.Operations.Cqrs;
using Vk.Schema;

namespace VkApi.Controllers;
[Route("vk/api/v1/[controller]")]
[ApiController]

public class UserFavoriteMovieGenresController : ControllerBase
{
    private readonly IMediator mediator;
    
    public UserFavoriteMovieGenresController(IMediator mediator)
    {
        this.mediator = mediator;
    }
    
    [HttpGet]
    public async Task<List<UserFavoriteMovieGenresResponse>> Get()
    {
        var operation = new GetAllUserFavoriteMovieGenresQuery();
        var result = await mediator.Send(operation);
        return result.Response ;
    }

    [HttpGet("{id}")]
    public async Task<UserFavoriteMovieGenresResponse> Get(int id)
    {
        var operation = new GetUserFavoriteMovieGenresById(id);
        var result = await mediator.Send(operation);
        return result.Response;
    }
    
    [HttpPost]
    public async Task <String> Create([FromBody] UserFavoriteMovieGenresCreateRequest request)
    {
        var operation = new CreateUserFavoriteMovieGenresCommand(request);
        var result = await mediator.Send(operation);
        return result.Message;
    }
    
    [HttpPut("{id}")]
    public async  Task<String> Put(int id, [FromBody] UserFavoriteMovieGenresUpdateRequest request)
    {
        var operation = new UpdateUserFavoriteMovieGenresCommand(request,id);
        var result = await mediator.Send(operation);
        return result.Message;
    }
    
    [HttpDelete("{id}")]
    public async Task <String> DeleteById(int id)
    {
        var operation = new DeleteUserFavoriteMovieGenresCommand(id);
        var result = await mediator.Send(operation);
        return result.Message;
    }
}