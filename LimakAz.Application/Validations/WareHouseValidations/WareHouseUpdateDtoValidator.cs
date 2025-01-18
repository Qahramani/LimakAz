using FluentValidation;

namespace LimakAz.Application.Validations.WareHouseValidations;

public class WareHouseUpdateDtoValidator : AbstractValidator<AddressLineUpdateDto>
{
    public WareHouseUpdateDtoValidator()
    {
        RuleFor(x => x.Key).NotEmpty().WithMessage("Boş ola bilməz");
        RuleFor(x => x.Value).NotEmpty().WithMessage("Boş ola bilməz");
    }
}
