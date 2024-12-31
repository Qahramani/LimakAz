using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimakAz.Application.Validations.CountryValidators;

public class CountryCreateValidator : AbstractValidator<CountryCreateDto>
{
    public CountryCreateValidator()
    {
        RuleFor(x => x.ImageFile).NotEmpty().WithMessage("Şəkil boş ola bilməz");
        RuleForEach(x => x.CountryDetails).ChildRules(details =>
        {
            details.RuleFor(d => d.Name)
                .NotEmpty().WithMessage("Boş ola bilməz")
                .MaximumLength(100).WithMessage("Uzunluq 100 simvoldan artıq ola bilməz");
        });
    }
}
