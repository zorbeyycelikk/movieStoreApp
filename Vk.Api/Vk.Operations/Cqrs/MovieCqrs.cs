using MediatR;
using Vk.Base.Response;
using Vk.Schema;

namespace Vk.Operations.Cqrs;

public record CreateMovieCommand(MovieCreateRequest Model) : IRequest<ApiResponse>;
public record UpdateMovieCommand(MovieUpdateRequest Model,int Id) : IRequest<ApiResponse>;
public record DeleteMovieCommand(int Id) : IRequest<ApiResponse>;

public record GetAllMovieQuery() : IRequest<ApiResponse<List<MovieResponse>>>;
public record GetMovieById(int Id) : IRequest<ApiResponse<MovieResponse>>;