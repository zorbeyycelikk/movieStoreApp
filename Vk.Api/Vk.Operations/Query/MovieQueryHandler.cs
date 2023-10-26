using AutoMapper;
using MediatR;
using Vk.Base.Response;
using Vk.Data.Domain;
using Vk.Data.Uow;
using Vk.Operations.Cqrs;
using Vk.Schema;

namespace Vk.Operations.Query;

public class MovieQueryHandler :
    IRequestHandler<GetAllMovieQuery, ApiResponse<List<MovieResponse>>>,
    IRequestHandler<GetMovieById, ApiResponse<MovieResponse>>
{
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;
    
    public MovieQueryHandler(IMapper mapper,IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }
    
    public async Task<ApiResponse<List<MovieResponse>>> Handle(GetAllMovieQuery request, CancellationToken cancellationToken)
    {
        List<Movie> x =  await unitOfWork.MovieRepository.GetAll(cancellationToken,"Genre" , "Director","Actors");
        List<MovieResponse> response = mapper.Map<List<MovieResponse>>(x);
        return new ApiResponse<List<MovieResponse>>(response);
    }

    public async Task<ApiResponse<MovieResponse>> Handle(GetMovieById request, CancellationToken cancellationToken)
    {
        Movie x = await unitOfWork.MovieRepository.GetById(request.Id, cancellationToken,"Genre" , "Director","Actors");
        if (x is null)
        {
            return new ApiResponse<MovieResponse>("Error");
        }
        MovieResponse response = mapper.Map<MovieResponse>(x);
        return new ApiResponse<MovieResponse>(response);
    }
}