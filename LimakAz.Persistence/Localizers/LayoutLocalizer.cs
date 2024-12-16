using Microsoft.Extensions.Localization;

namespace LimakAz.Persistence.Localizers;

public class LayoutLocalizer
{
    private readonly IStringLocalizer _localizer;

    public LayoutLocalizer(IStringLocalizerFactory factory)
    {
        _localizer = factory.Create("Layout", "LimakAz.Presentation");
    }

    public string GetValue(string key)
    {
        return _localizer.GetString(key);
    }
}

