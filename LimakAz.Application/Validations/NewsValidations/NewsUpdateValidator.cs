using FluentValidation;

namespace LimakAz.Application.Validations.NewsValidations;

public class NewsUpdateValidator : AbstractValidator<NewsUpdateDto>
{
    public NewsUpdateValidator()
    {
        RuleForEach(x => x.NewsDetails).ChildRules(details =>
        {
            details.RuleFor(d => d.Title)
                .NotEmpty().WithMessage("Boş ola bilməz")
                .MaximumLength(100).WithMessage("Uzunluq 100 simvoldan artıq ola bilməz");

            details.RuleFor(d => d.Description)
               .NotEmpty().WithMessage("Boş ola bilməz")
               .MaximumLength(2048).WithMessage("Uzunluq 2048 simvoldan artıq ola bilməz");
        });
    }
}
