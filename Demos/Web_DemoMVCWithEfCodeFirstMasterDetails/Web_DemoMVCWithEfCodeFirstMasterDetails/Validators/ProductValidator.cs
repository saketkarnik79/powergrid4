using FluentValidation;
using Web_DemoMVCWithEfCodeFirstMasterDetails.Models;

namespace Web_DemoMVCWithEfCodeFirstMasterDetails.Validators
{
    public class ProductValidator: AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Product Name is required.")
                .Length(2, 100).WithMessage("Product Name must be between 2 and 100 characters.");

            RuleFor(p => p.Price)
                .NotEmpty().WithMessage("Product Price is required.")
                .GreaterThan(0).WithMessage("Product Price must be greater than 0.");

            RuleFor(p => p.CategoryId)
                .NotEmpty().WithMessage("Category ID is required.")
                .GreaterThan(0).WithMessage("Category ID must be greater than 0.");

            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("Product ID is required.")
                .GreaterThan(0).WithMessage("Product ID must be greater than 0.");
        }
    }
}
