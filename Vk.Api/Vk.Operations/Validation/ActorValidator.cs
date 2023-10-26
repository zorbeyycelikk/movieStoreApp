using FluentValidation;
using Vk.Schema;

namespace Vk.Operations.Validation;

public class CreateActorValidator: AbstractValidator<ActorCreateRequest>
{
    public CreateActorValidator()
    {
        RuleFor(x => x.ActorNumber).NotEmpty();
        RuleFor(x => x.ActorFirstName).NotEmpty().MaximumLength(50);
        RuleFor(x => x.ActorLastName).NotEmpty().MaximumLength(50);
    }
}

public class UpdateActorValidator: AbstractValidator<ActorUpdateRequest>
{
    public UpdateActorValidator()
    {
        RuleFor(x => x.ActorFirstName).NotEmpty().MaximumLength(50);
        RuleFor(x => x.ActorLastName).NotEmpty().MaximumLength(50);
    }
}