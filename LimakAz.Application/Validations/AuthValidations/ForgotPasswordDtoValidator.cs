using FluentValidation;
using LimakAz.Application.Interfaces.Helpers;

namespace LimakAz.Application.Validations.AuthValidations;

public class ForgotPasswordDtoValidator : AbstractValidator<ForgotPasswordDto>
{
    public ForgotPasswordDtoValidator(IValidationMessageProvider messageProvider)
    {
        RuleFor(x => x.Email)
           .NotEmpty().WithMessage(messageProvider.GetValue("Email_Required"))
           .MaximumLength(100).WithMessage(messageProvider.GetValue("Email_Length"));

    }
}
