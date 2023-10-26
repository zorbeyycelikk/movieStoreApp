using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Vk.Base.Response;
using Vk.Data.Domain;
using Vk.Data.Uow;
using Vk.Operations.Cqrs;

namespace Vk.Operations.Command;

public class ActorCommandHandler:
    IRequestHandler<CreateActorCommand, ApiResponse>,
    IRequestHandler<UpdateActorCommand, ApiResponse>,
    IRequestHandler<DeleteActorCommand, ApiResponse>
{
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;
    
    public ActorCommandHandler(IMapper mapper,IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<ApiResponse> Handle(CreateActorCommand request, CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.ActorRepository.GetAsQueryable()
           .SingleOrDefaultAsync(x => x.ActorNumber == request.Model.ActorNumber ,cancellationToken);
        if (entity is not null)
        {
            return new ApiResponse("Error");
        }
        Actor x = mapper.Map<Actor>(request.Model);
        unitOfWork.ActorRepository.Insert(x,cancellationToken);
        unitOfWork.Complete(cancellationToken);
        return new ApiResponse();
    }

    public async Task<ApiResponse> Handle(UpdateActorCommand request, CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.ActorRepository.GetById(request.Id, cancellationToken);
        if (entity is null)
        {
            return new ApiResponse("Error");
        }

        entity.ActorFirstName = request.Model.ActorFirstName;
        entity.ActorLastName = request.Model.ActorLastName;
        unitOfWork.ActorRepository.Update(entity);
        unitOfWork.Complete(cancellationToken);
        return new ApiResponse();
    }

    public async Task<ApiResponse> Handle(DeleteActorCommand request, CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.ActorRepository.GetById(request.Id, cancellationToken);
        if (entity is null)
        {
            return new ApiResponse("Error");
        }
        unitOfWork.ActorRepository.Delete(request.Id);
        unitOfWork.Complete(cancellationToken);
        return new ApiResponse();
    }
}