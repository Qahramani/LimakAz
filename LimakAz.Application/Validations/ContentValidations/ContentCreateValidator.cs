using FluentValidation;

namespace LimakAz.Application.Validations.ContentValidations;

public class ContentCreateValidator : AbstractValidator<ContentCreateDto>
{
    public ContentCreateValidator()
    {
        RuleFor(x => x.PageType).NotEmpty().WithMessage("Boş ola bilməz")
            .IsInEnum().WithMessage("Düzgün dəyər daxil edin");
        RuleForEach(x => x.ContentDetails).ChildRules(details =>
        {
            details.RuleFor(x => x.Key)
            .NotEmpty().WithMessage("Boş ola bilməz")
                .MaximumLength(256).WithMessage("Uzunluq 256 simvoldan artıq ola bilməz");
            details.RuleFor(x => x.Value)
           .NotEmpty().WithMessage("Boş ola bilməz")
               .MaximumLength(2048).WithMessage("Uzunluq 2048 simvoldan artıq ola bilməz");
        });
    }
}
