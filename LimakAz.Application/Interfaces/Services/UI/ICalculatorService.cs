namespace LimakAz.Application.Interfaces.Services.UI;

public interface ICalculatorService
{   
    CalculatorDto GetCalculatorDto(LanguageType language = LanguageType.Azerbaijan);
    Task<CalculatorDto> CalculateAsync(CalculatorDto dto, LanguageType language = LanguageType.Azerbaijan);
}
