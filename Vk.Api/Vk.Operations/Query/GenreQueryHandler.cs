using AutoMapper;
using MediatR;
using Vk.Base.Response;
using Vk.Data.Domain;
using Vk.Data.Uow;
using Vk.Operations.Cqrs;
using Vk.Schema;

namespace Vk.Operations.Query;

public class GenreQueryHandler :
    IRequestHandler<GetAllGenreQuery, ApiResponse<List<GenreResponse>>>,
    IRequestHandler<GetGenreById, ApiResponse<GenreResponse>>
{
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;
    
    public GenreQueryHandler(IMapper mapper,IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }
    
    public async Task<ApiResponse<List<GenreResponse>>> Handle(GetAllGenreQuery request, CancellationToken cancellationToken)
    {
        List<Genre> x =  await unitOfWork.GenreRepository.GetAll(cancellationToken,"Movies");
        List<GenreResponse> response = mapper.Map<List<GenreResponse>>(x);
        return new ApiResponse<List<GenreResponse>>(response);
    }

    public async Task<ApiResponse<GenreResponse>> Handle(GetGenreById request, CancellationToken cancellationToken)
    {
        Genre x = await unitOfWork.GenreRepository.GetById(request.Id, cancellationToken,"Movies");
        if (x is null)
        {
            return new ApiResponse<GenreResponse>("Error");
        }
        GenreResponse response = mapper.Map<GenreResponse>(x);
        return new ApiResponse<GenreResponse>(response);
    }
}