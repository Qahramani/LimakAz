using FluentValidation;
using LimakAz.Application.DTOs.AuthDto;
using LimakAz.Application.Interfaces.Helpers;

namespace LimakAz.Application.Validations.AuthValidations;

public class RegisterDtoValidator : AbstractValidator<RegisterDto>
{
    public RegisterDtoValidator(IValidationMessageProvider messageProvider)
    {
        RuleFor(x => x.Firstname)
           .NotEmpty().WithMessage(messageProvider.GetValue("Firstname_Required"))
           .MaximumLength(50).WithMessage(messageProvider.GetValue("Firstname_Length"));

        RuleFor(x => x.Lastname)
            .NotEmpty().WithMessage(messageProvider.GetValue("Lastname_Required"))
            .MaximumLength(50).WithMessage(messageProvider.GetValue("Lastname_Length"));

        RuleFor(x => x.FinCode)
            .NotEmpty().WithMessage(messageProvider.GetValue("FinCode_Required"))
            .Length(7).WithMessage(messageProvider.GetValue("FinCode_Length"));

        RuleFor(x => x.SerialNumber)
            .NotEmpty().WithMessage(messageProvider.GetValue("SerialNumber_Required"));

        RuleFor(x => x.Address)
            .NotEmpty().WithMessage(messageProvider.GetValue("Address_Required"));

        RuleFor(x => x.IsTermsAccepted)
            .Equal(true).WithMessage(messageProvider.GetValue("IsTermsAccepted"));

        RuleFor(x => x.AZNBalance)
            .GreaterThanOrEqualTo(0).WithMessage(messageProvider.GetValue("AZNBalance_Min"));

        RuleFor(x => x.TRYBalance)
            .GreaterThanOrEqualTo(0).WithMessage(messageProvider.GetValue("TRYBalance_Min"));

        RuleFor(x => x.BirthDate)
            .NotEmpty().WithMessage(messageProvider.GetValue("BirthDate_Valid"))
            .LessThan(DateTime.Now).WithMessage(messageProvider.GetValue("BirthDate_Valid"));

        RuleFor(x => x.LocalPointId)
            .GreaterThan(0).WithMessage(messageProvider.GetValue("LocalPoint_Required"));

        RuleFor(x => x.GenderId)
            .GreaterThan(0).WithMessage(messageProvider.GetValue("Gender_Required"));

        RuleFor(x => x.CitizenShipId)
            .GreaterThan(0).WithMessage(messageProvider.GetValue("CitizenShip_Required"));

        RuleFor(x => x.UserPositionId)
            .GreaterThan(0).WithMessage(messageProvider.GetValue("UserPosition_Required"));
    }

}
