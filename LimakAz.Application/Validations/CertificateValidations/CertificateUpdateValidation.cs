using FluentValidation;

namespace LimakAz.Application.Validations.CertificateValidations;

public class CertificateUpdateValidation : AbstractValidator<CertificateUpdateDto>
{
    public CertificateUpdateValidation()
    {
        RuleFor(x => x.Link).NotEmpty().MaximumLength(256).WithMessage("Uzunluq asir");
    }
}