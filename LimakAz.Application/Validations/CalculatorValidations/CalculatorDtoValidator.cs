using FluentValidation;
using LimakAz.Application.Interfaces.Helpers;

namespace LimakAz.Application.Validations.CalculatorValidations;

public class CalculatorDtoValidator : AbstractValidator<CalculatorDto>
{
    public CalculatorDtoValidator(IValidationMessageProvider messageProvider)
    {
        RuleFor(x => x.Count)
           .NotEmpty().WithMessage(messageProvider.GetValue("CannotBeEmpty"))
           .InclusiveBetween(1, 1000).WithMessage(messageProvider.GetValue("Invalid_Input"));
        RuleFor(x => x.Weight)
            .NotEmpty().WithMessage(messageProvider.GetValue("CannotBeEmpty"))
            .InclusiveBetween(0.001M, 100M).WithMessage(messageProvider.GetValue("Invalid_Input"));
        RuleFor(x => x.Width)
            .Must(h => h == null || h >= 0 && h <= 10000).WithMessage(messageProvider.GetValue("Invalid_Input"));
        RuleFor(x => x.Height)
            .Must(h => h == null || h >= 0 && h <= 10000).WithMessage(messageProvider.GetValue("Invalid_Input"));
        RuleFor(x => x.Lenght)
            .Must(h => h == null || h >= 0 && h <= 10000).WithMessage(messageProvider.GetValue("Invalid_Input"));

    }
}
