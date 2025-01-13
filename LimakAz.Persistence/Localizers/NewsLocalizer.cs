using Microsoft.Extensions.Localization;

namespace LimakAz.Persistence.Localizers;

public class NewsLocalizer
{
    private readonly IStringLocalizer _stringLocalizer;

    public NewsLocalizer(IStringLocalizerFactory stringLocalizer)
    {
        _stringLocalizer = stringLocalizer.Create("News", "LimakAz.Presentation");
    }

    public string GetValue(string key)
    {
        return _stringLocalizer.GetString(key);
    }
}
