﻿using FluentValidation;

namespace LimakAz.Application.Validations.ShopValidations;

public class ShopCreateValidator : AbstractValidator<ShopCreateDto>
{
    public ShopCreateValidator()
    {
        RuleFor(x => x.ImageFile).NotEmpty().WithMessage("Şəkil boş ola bilməz");
        RuleFor(x => x.CountryId).NotEmpty().WithMessage("Boş ola bilməz");
        RuleFor(d => d.Link)
                .NotEmpty().WithMessage("Boş ola bilməz")
                .MaximumLength(256).WithMessage("Uzunluq 256 simvoldan artıq ola bilməz");

    }
}
