using FluentValidation;
using Vk.Schema;

namespace Vk.Operations.Validation;

public class CreateMovieValidator: AbstractValidator<MovieCreateRequest>
{
    public CreateMovieValidator()
    {
        RuleFor(x => x.MovieNumber).NotEmpty();
        RuleFor(x => x.MovieName).NotEmpty().MaximumLength(50);
        RuleFor(x => x.MovieYear).NotEmpty().GreaterThan(0)
            .WithMessage("Movie Year must be greater than 0.")
            .LessThanOrEqualTo(9999)
            .WithMessage("Movie Year must be less than or equal to 9999.");
        RuleFor(x => x.DirectorId).NotEmpty();
        RuleFor(x => x.GenreId).NotEmpty();
    }
}

public class UpdateMovieValidator: AbstractValidator<MovieUpdateRequest>
{
    public UpdateMovieValidator()
    {
        RuleFor(x => x.MovieName).NotEmpty().MaximumLength(50);
        RuleFor(x => x.MovieYear).NotEmpty().GreaterThan(0)
            .WithMessage("Movie Year must be greater than 0.")
            .LessThanOrEqualTo(9999)
            .WithMessage("Movie Year must be less than or equal to 9999.");
    }
}