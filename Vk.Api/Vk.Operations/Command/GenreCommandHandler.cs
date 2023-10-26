using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Vk.Base.Response;
using Vk.Data.Domain;
using Vk.Data.Uow;
using Vk.Operations.Cqrs;

namespace Vk.Operations.Command;

public class GenreCommandHandler:
    IRequestHandler<CreateGenreCommand, ApiResponse>,
    IRequestHandler<UpdateGenreCommand, ApiResponse>,
    IRequestHandler<DeleteGenreCommand, ApiResponse>
{
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;
    
    public GenreCommandHandler(IMapper mapper,IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<ApiResponse> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.GenreRepository.GetAsQueryable()
           .SingleOrDefaultAsync(x => x.GenreNumber == request.Model.GenreNumber ,cancellationToken);
        if (entity is not null)
        {
            return new ApiResponse("Error");
        }
        Genre x = mapper.Map<Genre>(request.Model);
        unitOfWork.GenreRepository.Insert(x,cancellationToken);
        unitOfWork.Complete(cancellationToken);
        return new ApiResponse();
    }

    public async Task<ApiResponse> Handle(UpdateGenreCommand request, CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.GenreRepository.GetById(request.Id, cancellationToken);
        if (entity is null)
        {
            return new ApiResponse("Error");
        }
        entity.GenreName = request.Model.GenreName;
        unitOfWork.GenreRepository.Update(entity);
        unitOfWork.Complete(cancellationToken);
        return new ApiResponse();
    }

    public async Task<ApiResponse> Handle(DeleteGenreCommand request, CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.GenreRepository.GetById(request.Id, cancellationToken);
        if (entity is null)
        {
            return new ApiResponse("Error");
        }
        unitOfWork.GenreRepository.Delete(request.Id);
        unitOfWork.Complete(cancellationToken);
        return new ApiResponse();
    }
}