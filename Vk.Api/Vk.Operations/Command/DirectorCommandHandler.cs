using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Vk.Base.Response;
using Vk.Data.Domain;
using Vk.Data.Uow;
using Vk.Operations.Cqrs;

namespace Vk.Operations.Command;

public class DirectorCommandHandler:
    IRequestHandler<CreateDirectorCommand, ApiResponse>,
    IRequestHandler<UpdateDirectorCommand, ApiResponse>,
    IRequestHandler<DeleteDirectorCommand, ApiResponse>
{
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;
    
    public DirectorCommandHandler(IMapper mapper,IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<ApiResponse> Handle(CreateDirectorCommand request, CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.DirectorRepository.GetAsQueryable()
           .SingleOrDefaultAsync(x => x.DirectorNumber == request.Model.DirectorNumber ,cancellationToken);
        if (entity is not null)
        {
            return new ApiResponse("Error");
        }
        Director x = mapper.Map<Director>(request.Model);
        unitOfWork.DirectorRepository.Insert(x,cancellationToken);
        unitOfWork.Complete(cancellationToken);
        return new ApiResponse();
    }

    public async Task<ApiResponse> Handle(UpdateDirectorCommand request, CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.DirectorRepository.GetById(request.Id, cancellationToken);
        if (entity is null)
        {
            return new ApiResponse("Error");
        }

        entity.DirectorFirstName = request.Model.DirectorFirstName;
        entity.DirectorLastName = request.Model.DirectorLastName;
        unitOfWork.DirectorRepository.Update(entity);
        unitOfWork.Complete(cancellationToken);
        return new ApiResponse();
    }

    public async Task<ApiResponse> Handle(DeleteDirectorCommand request, CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.DirectorRepository.GetById(request.Id, cancellationToken);
        if (entity is null)
        {
            return new ApiResponse("Error");
        }
        unitOfWork.DirectorRepository.Delete(request.Id);
        unitOfWork.Complete(cancellationToken);
        return new ApiResponse();
    }
}