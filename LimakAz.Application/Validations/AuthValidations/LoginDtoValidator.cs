using FluentValidation;
using LimakAz.Application.Interfaces.Helpers;

namespace LimakAz.Application.Validations.AuthValidations;

public class LoginDtoValidator : AbstractValidator<LoginDto>
{
    public LoginDtoValidator(IValidationMessageProvider messageProvider)
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage(messageProvider.GetValue("Email_Required"))
            .MaximumLength(100).WithMessage(messageProvider.GetValue("Email_Length"));

        RuleFor(x => x.Password)
           .NotEmpty().WithMessage(messageProvider.GetValue("Password_Required"))
           .MaximumLength(100).WithMessage(messageProvider.GetValue("Password_Length"));

    }
}
