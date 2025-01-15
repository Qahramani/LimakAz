using FluentValidation;
using LimakAz.Application.Interfaces.Helpers;

namespace LimakAz.Application.Validations.UserPanelValidations;

public class ProfileUpdateValidator : AbstractValidator<UserProfileUpdateDto>
{
    public ProfileUpdateValidator(IValidationMessageProvider messageProvider)
    {
        RuleFor(x => x.Firstname)
           .NotEmpty().WithMessage(messageProvider.GetValue("Firstname_Required"))
           .MaximumLength(50).WithMessage(messageProvider.GetValue("Firstname_Length"));

        RuleFor(x => x.Lastname)
            .NotEmpty().WithMessage(messageProvider.GetValue("Lastname_Required"))
            .MaximumLength(100).WithMessage(messageProvider.GetValue("Lastname_Length"));


        RuleFor(x => x.Address)
            .NotEmpty().WithMessage(messageProvider.GetValue("Address_Required"))
            .Length(10, 200).WithMessage(messageProvider.GetValue("Address_Length"));

        RuleFor(x => x.BirthDate)
        .NotEmpty().WithMessage(messageProvider.GetValue("BirthDate_Valid"))
          .LessThan(DateTime.Now).WithMessage(messageProvider.GetValue("BirthDate_Valid"));

        RuleFor(x => x.PhoneNumber)
   .NotEmpty().WithMessage(messageProvider.GetValue("PhoneNumber_Required"))
   .Length(7).WithMessage(messageProvider.GetValue("PhoneNumber_Length"))
   .Matches(@"^\d{7}$").WithMessage(messageProvider.GetValue("PhoneNumber_Numeric"));
    }
}
