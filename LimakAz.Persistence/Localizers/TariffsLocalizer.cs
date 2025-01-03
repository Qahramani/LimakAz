using Microsoft.Extensions.Localization;

namespace LimakAz.Persistence.Localizers;

public class TariffsLocalizer
{
    private readonly IStringLocalizer _stringLocalizer;

    public TariffsLocalizer(IStringLocalizerFactory stringLocalizer)
    {
        _stringLocalizer = stringLocalizer.Create("Tariff", "LimakAz.Presentation");
    }

    public string GetValue(string key)
    {
        return _stringLocalizer.GetString(key);
    }
}