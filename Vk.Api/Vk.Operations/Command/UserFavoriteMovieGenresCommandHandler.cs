using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Vk.Base.Response;
using Vk.Data.Domain;
using Vk.Data.Uow;
using Vk.Operations.Cqrs;

namespace Vk.Operations.Command;

public class UserFavoriteMovieGenresCommandHandler:
    IRequestHandler<CreateUserFavoriteMovieGenresCommand, ApiResponse>,
    IRequestHandler<UpdateUserFavoriteMovieGenresCommand, ApiResponse>,
    IRequestHandler<DeleteUserFavoriteMovieGenresCommand, ApiResponse>
{
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;
    
    public UserFavoriteMovieGenresCommandHandler(IMapper mapper,IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<ApiResponse> Handle(CreateUserFavoriteMovieGenresCommand request, CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.UserFavoriteMovieGenresRepository.GetAsQueryable().Where(x =>
                x.CustomerId == request.Model.CustomerId && x.FavoriteGenreId == request.Model.FavoriteGenreId)
            .SingleOrDefaultAsync(cancellationToken);
        
        if (entity is not null)
        {
            return new ApiResponse("Error");
        }
        
        // Böyle bir kategori var mı onu check eder
        var entity_genre = await unitOfWork.GenreRepository.GetAsQueryable()
            .Where(x => x.Id == request.Model.FavoriteGenreId)
            .SingleOrDefaultAsync(cancellationToken);
        
        if (entity_genre is null)
        {
            return new ApiResponse("Error");
        }
        
        UserFavoriteMovieGenres x = mapper.Map<UserFavoriteMovieGenres>(request.Model);
        unitOfWork.UserFavoriteMovieGenresRepository.Insert(x,cancellationToken);
        unitOfWork.Complete(cancellationToken);
        return new ApiResponse();
    }

    public async Task<ApiResponse> Handle(UpdateUserFavoriteMovieGenresCommand request, CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.UserFavoriteMovieGenresRepository.GetById(request.Id, cancellationToken , "Customer","Genre");
        if (entity is null)
        {
            return new ApiResponse("Error");
        }

        var entity_genre = await unitOfWork.GenreRepository.GetAsQueryable()
            .Where(x => x.Id == request.Model.FavoriteGenreId)
            .SingleOrDefaultAsync(cancellationToken);
        
        if (entity_genre is null)
        {
            return new ApiResponse("Error");
        }
        
        entity.FavoriteGenreId = request.Model.FavoriteGenreId;
        unitOfWork.UserFavoriteMovieGenresRepository.Update(entity);
        unitOfWork.Complete(cancellationToken);
        return new ApiResponse();
    }

    public async Task<ApiResponse> Handle(DeleteUserFavoriteMovieGenresCommand request, CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.UserFavoriteMovieGenresRepository.GetById(request.Id, cancellationToken);
        if (entity is null)
        {
            return new ApiResponse("Error");
        }
        unitOfWork.UserFavoriteMovieGenresRepository.Delete(request.Id);
        unitOfWork.Complete(cancellationToken);
        return new ApiResponse();
    }
}