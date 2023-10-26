using AutoMapper;
using MediatR;
using Vk.Base.Response;
using Vk.Data.Domain;
using Vk.Data.Uow;
using Vk.Operations.Cqrs;
using Vk.Schema;

namespace Vk.Operations.Query;

public class DirectorQueryHandler :
    IRequestHandler<GetAllDirectorQuery, ApiResponse<List<DirectorResponse>>>,
    IRequestHandler<GetDirectorById, ApiResponse<DirectorResponse>>
{
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;
    
    public DirectorQueryHandler(IMapper mapper,IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }
    
    public async Task<ApiResponse<List<DirectorResponse>>> Handle(GetAllDirectorQuery request, CancellationToken cancellationToken)
    {
        List<Director> x =  await unitOfWork.DirectorRepository.GetAll(cancellationToken,"Movies");
        List<DirectorResponse> response = mapper.Map<List<DirectorResponse>>(x);
        return new ApiResponse<List<DirectorResponse>>(response);
    }

    public async Task<ApiResponse<DirectorResponse>> Handle(GetDirectorById request, CancellationToken cancellationToken)
    {
        Director x = await unitOfWork.DirectorRepository.GetById(request.Id, cancellationToken,"Movies");
        if (x is null)
        {
            return new ApiResponse<DirectorResponse>("Error");
        }
        DirectorResponse response = mapper.Map<DirectorResponse>(x);
        return new ApiResponse<DirectorResponse>(response);
    }
}