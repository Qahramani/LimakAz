using FluentValidation;

namespace LimakAz.Application.Validations.CountryValidators;

public class CountryUpdateValidator : AbstractValidator<CountryUpdateDto>
{
    public CountryUpdateValidator()
    {
        RuleForEach(x => x.CountryDetails).ChildRules(details =>
        {
            details.RuleFor(d => d.Name)
                .NotEmpty().WithMessage("Boş ola bilməz")
                .MaximumLength(100).WithMessage("Uzunluq 100 simvoldan artıq ola bilməz");
        });
    }
}
