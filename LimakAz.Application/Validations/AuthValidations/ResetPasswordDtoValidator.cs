    using FluentValidation;
using LimakAz.Application.Interfaces.Helpers;

namespace LimakAz.Application.Validations.AuthValidations;

public class ResetPasswordDtoValidator : AbstractValidator<ResetPasswordDto>
{
    public ResetPasswordDtoValidator(IValidationMessageProvider messageProvider)
    {
        RuleFor(x => x.Email)
           .NotEmpty().WithMessage(messageProvider.GetValue("Email_Required"))
           .MaximumLength(100).WithMessage(messageProvider.GetValue("Email_Length"));

        RuleFor(x => x.NewPassword)
           .NotEmpty().WithMessage(messageProvider.GetValue("Password_Required"))
           .MaximumLength(100).WithMessage(messageProvider.GetValue("Password_Length"));

        RuleFor(x => x.ConfirmPassword)
            .NotEmpty().WithMessage(messageProvider.GetValue("ConfirmPassword_Required"))
            .Equal(x => x.NewPassword).WithMessage(messageProvider.GetValue("Passwords_NotMatch"));
    }
}
