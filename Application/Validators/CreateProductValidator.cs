using Application.Features.Products.Commands;
using FluentValidation;

namespace Application.Validators
{
    public class CreateProductValidator: AbstractValidator<CreateProductCommand>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Price).GreaterThan(0);
            RuleFor(x => x.CategoryId).NotEmpty();
        }
    }
}

