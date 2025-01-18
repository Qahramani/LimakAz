using FluentValidation;

namespace LimakAz.Application.Validations.WareHouseValidations;

public class WareHouseCreateDtoValidator : AbstractValidator<AddressLineCreateDto>
{
    public WareHouseCreateDtoValidator()
    {
        RuleFor(x => x.Key).NotEmpty().WithMessage("Boş ola bilməz");
        RuleFor(x => x.Value).NotEmpty().WithMessage("Boş ola bilməz");
    }
}
