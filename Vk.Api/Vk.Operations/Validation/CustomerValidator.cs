using FluentValidation;
using Vk.Schema;

namespace Vk.Operations.Validation;

public class CreateCustomerValidator: AbstractValidator<CustomerCreateRequest>
{
    public CreateCustomerValidator()
    {
        RuleFor(x => x.CustomerNumber).NotEmpty();
        RuleFor(x => x.CustomerFirstName).NotEmpty().MaximumLength(50);
        RuleFor(x => x.CustomerLastName).NotEmpty().MaximumLength(50);
    }
}

public class UpdateCustomerValidator: AbstractValidator<CustomerUpdateRequest>
{
    public UpdateCustomerValidator()
    {
        RuleFor(x => x.CustomerFirstName).NotEmpty().MaximumLength(50);
        RuleFor(x => x.CustomerLastName).NotEmpty().MaximumLength(50);
    }
}