using AutoMapper;
using MediatR;
using Vk.Base.Response;
using Vk.Data.Domain;
using Vk.Data.Uow;
using Vk.Operations.Cqrs;
using Vk.Schema;

namespace Vk.Operations.Query;

public class ActorQueryHandler :
    IRequestHandler<GetAllActorQuery, ApiResponse<List<ActorResponse>>>,
    IRequestHandler<GetActorById, ApiResponse<ActorResponse>>
{
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;
    
    public ActorQueryHandler(IMapper mapper,IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }
    
    public async Task<ApiResponse<List<ActorResponse>>> Handle(GetAllActorQuery request, CancellationToken cancellationToken)
    {
        List<Actor> x =  await unitOfWork.ActorRepository.GetAll(cancellationToken);
        List<ActorResponse> response = mapper.Map<List<ActorResponse>>(x);
        return new ApiResponse<List<ActorResponse>>(response);
    }

    public async Task<ApiResponse<ActorResponse>> Handle(GetActorById request, CancellationToken cancellationToken)
    {
        Actor x = await unitOfWork.ActorRepository.GetById(request.Id, cancellationToken);
        if (x is null)
        {
            return new ApiResponse<ActorResponse>("Error");
        }
        ActorResponse response = mapper.Map<ActorResponse>(x);
        return new ApiResponse<ActorResponse>(response);
    }
}