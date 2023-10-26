using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vk.Operations.Cqrs;
using Vk.Schema;

namespace VkApi.Controllers;
[Route("vk/api/v1/[controller]")]
[ApiController]

public class CustomerController : ControllerBase
{
    private readonly IMediator mediator;
    
    public CustomerController(IMediator mediator)
    {
        this.mediator = mediator;
    }
    
    [HttpGet]
    [Authorize(Roles = "Celik")]
    public async Task<List<CustomerResponse>> Get()
    {
        var operation = new GetAllCustomerQuery();
        var result = await mediator.Send(operation);
        return result.Response ;
    }
    
    [HttpGet("{id}")]
    [Authorize(Roles = "Celik")]
    public async Task<CustomerResponse> Get(int id)
    {
        var operation = new GetCustomerById(id);
        var result = await mediator.Send(operation);
        return result.Response;
    }
    
    [HttpPost]
    [Authorize(Roles = "Celik")]
    public async Task <String> Create([FromBody] CustomerCreateRequest request)
    {
        var operation = new CreateCustomerCommand(request);
        var result = await mediator.Send(operation);
        return result.Message;
    }
    
    [HttpPut("{id}")]
    [Authorize(Roles = "Celik")]
    public async  Task<String> Put(int id, [FromBody] CustomerUpdateRequest request)
    {
        var operation = new UpdateCustomerCommand(request,id);
        var result = await mediator.Send(operation);
        return result.Message;
    }
    
    [HttpDelete("{id}")]
    [Authorize(Roles = "Celik")]
    public async Task <String> DeleteById(int id)
    {
        var operation = new DeleteCustomerCommand(id);
        var result = await mediator.Send(operation);
        return result.Message;
    }
}