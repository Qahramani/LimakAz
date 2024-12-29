using FluentValidation;

namespace LimakAz.Application.Validations.CertificateValidations;

public class CertificateUpdateValidator : AbstractValidator<CertificateUpdateDto>
{
    public CertificateUpdateValidator()
    {
        RuleFor(x => x.Link).NotEmpty().WithMessage("boş ola bilməz").MaximumLength(256).WithMessage("Uzunluq 256 simvoldan böyük ola bilməz");
    }
}