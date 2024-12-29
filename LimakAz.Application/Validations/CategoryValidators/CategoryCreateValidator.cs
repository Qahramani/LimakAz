using FluentValidation;

namespace LimakAz.Application.Validations.CategoryValidators;

public class CategoryCreateValidator : AbstractValidator<CategoryCreateDto>
{
    public CategoryCreateValidator()
    {
        RuleFor(x => x.ImageFile).NotEmpty().WithMessage("Şəkil boş ola bilməz");
        RuleForEach(x => x.CategoryDetails).ChildRules(details =>
        {
            details.RuleFor(d => d.Name)
                .NotEmpty().WithMessage("Boş ola bilməz")
                .MaximumLength(100).WithMessage("Uzunluq 100 simvoldan artıq ola bilməz");
        });
    }
}
