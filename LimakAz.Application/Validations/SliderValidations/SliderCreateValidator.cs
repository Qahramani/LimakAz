using FluentValidation;

namespace LimakAz.Application.Validations.SliderValidations;

public class SliderCreateValidator : AbstractValidator<SliderCreateDto>
{
    public SliderCreateValidator()
    {
        RuleFor(x => x.ImageFile).NotEmpty().WithMessage("Şəkil boş ola bilməz");
    }
}
