using MediatR;
using Vk.Base.Response;
using Vk.Schema;

namespace Vk.Operations.Cqrs;

public record CreateCustomerCommand(CustomerCreateRequest Model) : IRequest<ApiResponse>;
public record UpdateCustomerCommand(CustomerUpdateRequest Model,int Id) : IRequest<ApiResponse>;
public record DeleteCustomerCommand(int Id) : IRequest<ApiResponse>;

public record GetAllCustomerQuery() : IRequest<ApiResponse<List<CustomerResponse>>>;
public record GetCustomerById(int Id) : IRequest<ApiResponse<CustomerResponse>>;