using AutoMapper;
using MediatR;
using Vk.Base.Response;
using Vk.Data.Domain;
using Vk.Data.Uow;
using Vk.Operations.Cqrs;
using Vk.Schema;

namespace Vk.Operations.Query;

public class UserFavoriteMovieGenresQueryHandler :
    IRequestHandler<GetAllUserFavoriteMovieGenresQuery, ApiResponse<List<UserFavoriteMovieGenresResponse>>>,
    IRequestHandler<GetUserFavoriteMovieGenresById, ApiResponse<UserFavoriteMovieGenresResponse>>
{
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;
    
    public UserFavoriteMovieGenresQueryHandler(IMapper mapper,IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }
    
    public async Task<ApiResponse<List<UserFavoriteMovieGenresResponse>>> Handle(GetAllUserFavoriteMovieGenresQuery request, CancellationToken cancellationToken)
    {
        List<UserFavoriteMovieGenres> x =  await unitOfWork.UserFavoriteMovieGenresRepository.GetAll(cancellationToken,"Customer");
        List<UserFavoriteMovieGenresResponse> response = mapper.Map<List<UserFavoriteMovieGenresResponse>>(x);
        return new ApiResponse<List<UserFavoriteMovieGenresResponse>>(response);
    }

    public async Task<ApiResponse<UserFavoriteMovieGenresResponse>> Handle(GetUserFavoriteMovieGenresById request, CancellationToken cancellationToken)
    {
        UserFavoriteMovieGenres x = await unitOfWork.UserFavoriteMovieGenresRepository.GetById(request.Id, cancellationToken,"Customer");
        if (x is null)
        {
            return new ApiResponse<UserFavoriteMovieGenresResponse>("Error");
        }
        UserFavoriteMovieGenresResponse response = mapper.Map<UserFavoriteMovieGenresResponse>(x);
        return new ApiResponse<UserFavoriteMovieGenresResponse>(response);
    }
}