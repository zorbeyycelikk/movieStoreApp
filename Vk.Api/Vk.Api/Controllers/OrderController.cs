using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vk.Base.Response;
using Vk.Operations.Cqrs;
using Vk.Schema;

namespace VkApi.Controllers;
[Route("vk/api/v1/[controller]")]
[ApiController]

public class OrderController : ControllerBase
{
    private readonly IMediator mediator;
    
    public OrderController(IMediator mediator)
    {
        this.mediator = mediator;
    }
    
    [HttpPost]
    public async Task <IActionResult> Post([FromBody] OrderCreateRequest request)
    {
        var operation = new CreateOrderCommand(request);
        var result = await mediator.Send(operation);
        return result.Success ? Ok(result.Response) : result.Message == "Error" ? NotFound() : BadRequest();
    }
}