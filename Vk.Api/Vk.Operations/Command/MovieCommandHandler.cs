using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Vk.Base.Response;
using Vk.Data.Domain;
using Vk.Data.Uow;
using Vk.Operations.Cqrs;

namespace Vk.Operations.Command;

public class MovieCommandHandler:
    IRequestHandler<CreateMovieCommand, ApiResponse>,
    IRequestHandler<UpdateMovieCommand, ApiResponse>,
    IRequestHandler<DeleteMovieCommand, ApiResponse>
{
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;
    
    public MovieCommandHandler(IMapper mapper,IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<ApiResponse> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.MovieRepository.GetAsQueryable()
           .SingleOrDefaultAsync(x => x.MovieNumber == request.Model.MovieNumber ,cancellationToken);
        if (entity is not null)
        {
            return new ApiResponse("Error");
        }
        Movie x = mapper.Map<Movie>(request.Model);
        unitOfWork.MovieRepository.Insert(x,cancellationToken);
        unitOfWork.Complete(cancellationToken);
        return new ApiResponse();
    }

    public async Task<ApiResponse> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.MovieRepository.GetById(request.Id, cancellationToken);
        if (entity is null)
        {
            return new ApiResponse("Error");
        }
        entity.MovieName = request.Model.MovieName;
        entity.MovieYear = request.Model.MovieYear;
        unitOfWork.MovieRepository.Update(entity);
        unitOfWork.Complete(cancellationToken);
        return new ApiResponse();
    }

    public async Task<ApiResponse> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.MovieRepository.GetById(request.Id, cancellationToken);
        if (entity is null)
        {
            return new ApiResponse("Error");
        }
        unitOfWork.MovieRepository.Delete(request.Id);
        unitOfWork.Complete(cancellationToken);
        return new ApiResponse();
    }
}