using MediatR;
using Vk.Base.Response;
using Vk.Schema;

namespace Vk.Operations.Cqrs;

public record CreateOrderCommand(OrderCreateRequest Model) : IRequest<ApiResponse<OrderResponse>>;
