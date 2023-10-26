using FluentValidation;
using Vk.Schema;

namespace Vk.Operations.Validation;

public class CreateGenreValidator: AbstractValidator<GenreCreateRequest>
{
    public CreateGenreValidator()
    {
        RuleFor(x => x.GenreNumber).NotEmpty();
        RuleFor(x => x.GenreName).NotEmpty().MaximumLength(50);
    }
}

public class UpdateGenreValidator: AbstractValidator<GenreUpdateRequest>
{
    public UpdateGenreValidator()
    {
        RuleFor(x => x.GenreName).NotEmpty().MaximumLength(50);
    }
}