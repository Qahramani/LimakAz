using FluentValidation;

namespace LimakAz.Application.Validations.TariffValidators;

public class TariffCreateDtoValidator : AbstractValidator<TariffCreateDto>
{
    public TariffCreateDtoValidator()
    {
        RuleFor(t => t.MinValue).GreaterThanOrEqualTo(0).WithMessage("Minimal çəki 0-dan kiçik ola bilməz.");
        RuleFor(t => t.MaxValue).GreaterThan(t => t.MinValue).WithMessage("Maksimal çəki minimal çəkidən böyük olmalıdır.");
        RuleFor(t => t.Price).GreaterThan(0).WithMessage("Qiymət 0-dan böyük olmalıdır.");
    }
}
