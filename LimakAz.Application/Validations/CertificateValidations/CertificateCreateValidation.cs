using FluentValidation;

namespace LimakAz.Application.Validations.CertificateValidations;

public class CertificateCreateValidation : AbstractValidator<CertificateCreateDto>
{
    public CertificateCreateValidation()
    {
        RuleFor(x => x.Link).NotEmpty().MaximumLength(256).WithMessage("Uzunluq asir");
    }
}
