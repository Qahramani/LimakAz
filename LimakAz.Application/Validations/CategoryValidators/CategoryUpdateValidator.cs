using FluentValidation;

namespace LimakAz.Application.Validations.CategoryValidators;

public class CategoryUpdateValidator : AbstractValidator<CategoryUpdateDto>
{
    public CategoryUpdateValidator()
    {
        RuleForEach(x => x.CategoryDetails).ChildRules(details =>
        {
            details.RuleFor(d => d.Name)
                .NotEmpty().WithMessage("Boş ola bilməz")
                .MaximumLength(100).WithMessage("Uzunluq 100 simvoldan artıq ola bilməz");
        });
    }
}