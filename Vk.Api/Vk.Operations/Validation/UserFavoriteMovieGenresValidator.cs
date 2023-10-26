using FluentValidation;
using Vk.Schema;

namespace Vk.Operations.Validation;

public class CreateUserFavoriteMovieGenresValidator: AbstractValidator<UserFavoriteMovieGenresCreateRequest>
{
    public CreateUserFavoriteMovieGenresValidator()
    {
        RuleFor(x => x.CustomerId).NotEmpty();
        RuleFor(x => x.FavoriteGenreId).NotEmpty();
    }
}

public class UpdateUserFavoriteMovieGenresValidator: AbstractValidator<UserFavoriteMovieGenresUpdateRequest>
{
    public UpdateUserFavoriteMovieGenresValidator()
    {
        RuleFor(x => x.FavoriteGenreId).NotEmpty();
    }
}