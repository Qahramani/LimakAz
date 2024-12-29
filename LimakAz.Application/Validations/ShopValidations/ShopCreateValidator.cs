using FluentValidation;
using LimakAz.Application.DTOs.ShopDtos;

namespace LimakAz.Application.Validations.ShopValidations;

internal class ShopCreateValidator : AbstractValidator<ShopCreateDto>
{
    public ShopCreateValidator()
    {
        RuleFor(x => x.ImageFile).NotEmpty().WithMessage("Şəkil boş ola bilməz");
        RuleFor(d => d.Link)
                .NotEmpty().WithMessage("Boş ola bilməz")
                .MaximumLength(256).WithMessage("Uzunluq 256 simvoldan artıq ola bilməz");

    }
}
