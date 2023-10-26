using MediatR;
using Vk.Base.Response;
using Vk.Schema;

namespace Vk.Operations.Cqrs;

public record CreateActorCommand(ActorCreateRequest Model) : IRequest<ApiResponse>;
public record UpdateActorCommand(ActorUpdateRequest Model,int Id) : IRequest<ApiResponse>;
public record DeleteActorCommand(int Id) : IRequest<ApiResponse>;

public record GetAllActorQuery() : IRequest<ApiResponse<List<ActorResponse>>>;
public record GetActorById(int Id) : IRequest<ApiResponse<ActorResponse>>;