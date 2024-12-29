using FluentValidation;

namespace LimakAz.Application.Validations.ShopValidations;

public class ShopUpdateValidator : AbstractValidator<ShopUpdateDto>
{
    public ShopUpdateValidator()
    {
        RuleFor(x => x.CountryId).NotEmpty().WithMessage("Boş ola bilməz");
        RuleFor(d => d.Link)
                .NotEmpty().WithMessage("Boş ola bilməz")
                .MaximumLength(256).WithMessage("Uzunluq 256 simvoldan artıq ola bilməz");

    }
}
