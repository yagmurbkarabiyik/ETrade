using ETrade.Application.ViewModels.Products;
using FluentValidation;


namespace ETrade.Application.Validators.Products
{
    public class CreateProductValidator : AbstractValidator<VM_Create_Product>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Please write product name!")
                .MaximumLength(150)
                .MinimumLength(2)
                    .WithMessage("Product name should be 2-150 character!");

            RuleFor(p => p.Stock)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Stock cannot be null!")
                .Must(s => s >= 0)
                    .WithMessage("Stock cannot be negative");

            RuleFor(p => p.Price)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Price cannot be null!")
                .Must(s => s >= 0)
                    .WithMessage("Price cannot be negative");

        }


    }
}
