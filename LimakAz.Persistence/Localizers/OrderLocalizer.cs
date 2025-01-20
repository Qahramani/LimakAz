using Microsoft.Extensions.Localization;

namespace LimakAz.Persistence.Localizers;

public class OrderLocalizer
{
    private readonly IStringLocalizer _stringLocalizer;

    public OrderLocalizer(IStringLocalizerFactory stringLocalizer)
    {
        _stringLocalizer = stringLocalizer.Create("Order", "LimakAz.Presentation");
    }

    public string GetValue(string key)
    {
        return _stringLocalizer.GetString(key);
    }
}
