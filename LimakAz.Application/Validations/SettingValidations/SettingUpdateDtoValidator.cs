using FluentValidation;


namespace LimakAz.Application.Validations;

public class SettingUpdateDtoValidator : AbstractValidator<SettingUpdateDto>
{
    public SettingUpdateDtoValidator()
    {
        RuleFor(x => x.Key).NotEmpty().WithMessage("Boş ola bilməz");
        RuleForEach(x => x.SettingDetails).ChildRules(details =>
        {
            details.RuleFor(d => d.Value)
                .NotEmpty().WithMessage("Boş ola bilməz")
                .MaximumLength(100).WithMessage("Uzunluq 100 simvoldan artıq ola bilməz");
        });
    }
}
