using Microsoft.Extensions.Localization;

namespace LimakAz.Persistence.Localizers;

public class ContentLocalizer
{
    private readonly IStringLocalizer _stringLocalizer;
    public ContentLocalizer(IStringLocalizerFactory stringLocalizer)
    {
        _stringLocalizer = stringLocalizer.Create("Content", "LimakAz.Presentation");
    }

    public string GetValue(string key)
    {
        return _stringLocalizer.GetString(key);
    }
}