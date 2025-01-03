using Microsoft.Extensions.Localization;

namespace LimakAz.Persistence.Localizers;

public class HomeLocalizer
{
    private readonly IStringLocalizer _localizer;

    public HomeLocalizer(IStringLocalizerFactory localizer)
    {
        _localizer = localizer.Create("Home", "LimakAz.Presentation");
    }

    public string GetValue(string key)
    {
        return _localizer.GetString(key);
    }
}