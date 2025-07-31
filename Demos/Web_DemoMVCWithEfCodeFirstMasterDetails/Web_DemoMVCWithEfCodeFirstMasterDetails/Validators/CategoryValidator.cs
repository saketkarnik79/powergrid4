using FluentValidation;
using Web_DemoMVCWithEfCodeFirstMasterDetails.Models;

namespace Web_DemoMVCWithEfCodeFirstMasterDetails.Validators
{
    public class CategoryValidator: AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Category Name is required.")
                .Length(2, 100).WithMessage("Category Name must be between 2 and 100 characters.");
           
            //RuleFor(c => c.CategoryId)
            //    .NotEmpty().WithMessage("Category ID is required.")
            //    .GreaterThan(0).WithMessage("Category ID must be greater than 0.");
        }
    }
}
