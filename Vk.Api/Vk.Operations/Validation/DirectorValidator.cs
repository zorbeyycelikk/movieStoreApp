using FluentValidation;
using Vk.Schema;

namespace Vk.Operations.Validation;

public class CreateDirectorValidator: AbstractValidator<DirectorCreateRequest>
{
    public CreateDirectorValidator()
    {
        RuleFor(x => x.DirectorNumber).NotEmpty();
        RuleFor(x => x.DirectorFirstName).NotEmpty().MaximumLength(50);
        RuleFor(x => x.DirectorLastName).NotEmpty().MaximumLength(50);
    }
}

public class UpdateDirectorValidator: AbstractValidator<DirectorUpdateRequest>
{
    public UpdateDirectorValidator()
    {
        RuleFor(x => x.DirectorFirstName).NotEmpty().MaximumLength(50);
        RuleFor(x => x.DirectorLastName).NotEmpty().MaximumLength(50);
    }
}