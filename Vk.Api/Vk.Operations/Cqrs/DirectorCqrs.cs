using MediatR;
using Vk.Base.Response;
using Vk.Schema;

namespace Vk.Operations.Cqrs;

public record CreateDirectorCommand(DirectorCreateRequest Model) : IRequest<ApiResponse>;
public record UpdateDirectorCommand(DirectorUpdateRequest Model,int Id) : IRequest<ApiResponse>;
public record DeleteDirectorCommand(int Id) : IRequest<ApiResponse>;

public record GetAllDirectorQuery() : IRequest<ApiResponse<List<DirectorResponse>>>;
public record GetDirectorById(int Id) : IRequest<ApiResponse<DirectorResponse>>;