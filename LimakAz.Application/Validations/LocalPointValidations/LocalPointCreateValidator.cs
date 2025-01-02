using FluentValidation;

namespace LimakAz.Application.Validations.LocalPointValidations;

public class LocalPointCreateValidator : AbstractValidator<LocalPointCreateDto>
{
    public LocalPointCreateValidator()
    {
        RuleForEach(x => x.LocalPointDetails).ChildRules(details =>
        {
            details.RuleFor(d => d.Name)
                .NotEmpty().WithMessage("Boş ola bilməz")
                .MaximumLength(50).WithMessage("Uzunluq 50 simvoldan artıq ola bilməz");
            details.RuleFor(d => d.Description)
                .NotEmpty().WithMessage("Boş ola bilməz")
                .MaximumLength(256).WithMessage("Uzunluq 256 simvoldan artıq ola bilməz");
            details.RuleFor(d => d.WorkingHourse)
                .NotEmpty().WithMessage("Boş ola bilməz")
                .MaximumLength(100).WithMessage("Uzunluq 100 simvoldan artıq ola bilməz");
        });
    }
}
