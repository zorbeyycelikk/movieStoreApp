using MediatR;
using Vk.Base.Response;
using Vk.Schema;

namespace Vk.Operations.Cqrs;

public record CreateGenreCommand(GenreCreateRequest Model) : IRequest<ApiResponse>;
public record UpdateGenreCommand(GenreUpdateRequest Model,int Id) : IRequest<ApiResponse>;
public record DeleteGenreCommand(int Id) : IRequest<ApiResponse>;

public record GetAllGenreQuery() : IRequest<ApiResponse<List<GenreResponse>>>;
public record GetGenreById(int Id) : IRequest<ApiResponse<GenreResponse>>;