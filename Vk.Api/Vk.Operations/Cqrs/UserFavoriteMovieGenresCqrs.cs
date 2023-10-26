using MediatR;
using Vk.Base.Response;
using Vk.Schema;

namespace Vk.Operations.Cqrs;

public record CreateUserFavoriteMovieGenresCommand(UserFavoriteMovieGenresCreateRequest Model) : IRequest<ApiResponse>;
public record UpdateUserFavoriteMovieGenresCommand(UserFavoriteMovieGenresUpdateRequest Model,int Id) : IRequest<ApiResponse>;
public record DeleteUserFavoriteMovieGenresCommand(int Id) : IRequest<ApiResponse>;

public record GetAllUserFavoriteMovieGenresQuery() : IRequest<ApiResponse<List<UserFavoriteMovieGenresResponse>>>;
public record GetUserFavoriteMovieGenresById(int Id) : IRequest<ApiResponse<UserFavoriteMovieGenresResponse>>;