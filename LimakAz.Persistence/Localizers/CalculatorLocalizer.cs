using Microsoft.Extensions.Localization;

namespace LimakAz.Persistence.Localizers;

public class CalculatorLocalizer
{
    private readonly IStringLocalizer _stringLocalizer;

    public CalculatorLocalizer(IStringLocalizerFactory stringLocalizer)
    {
        _stringLocalizer = stringLocalizer.Create("Calculator", "LimakAz.Presentation");
    }

    public string GetValue(string key)
    {
        return _stringLocalizer.GetString(key);
    }
}
