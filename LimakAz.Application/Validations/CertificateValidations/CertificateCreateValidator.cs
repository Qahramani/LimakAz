using FluentValidation;

namespace LimakAz.Application.Validations.CertificateValidations;

public class CertificateCreateValidator : AbstractValidator<CertificateCreateDto>
{
    public CertificateCreateValidator()
    {
        RuleFor(x => x.ImageFile).NotEmpty().WithMessage("Şəkil boş ola bilməz");
        RuleFor(x => x.Link).NotEmpty().WithMessage("boş ola bilməz").MaximumLength(256).WithMessage("Uzunluq 256 simvoldan böyük ola bilməz");
    }
}
