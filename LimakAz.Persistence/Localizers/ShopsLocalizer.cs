using Microsoft.Extensions.Localization;

namespace LimakAz.Persistence.Localizers;

public class ShopsLocalizer
{
    private readonly IStringLocalizer _stringLocalizer;

    public ShopsLocalizer(IStringLocalizerFactory stringLocalizer)
    {
        _stringLocalizer = stringLocalizer.Create("Shops", "LimakAz.Presentation");
    }

    public string GetValue(string key)
    {
        return _stringLocalizer.GetString(key);
    }
}