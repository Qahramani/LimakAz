using Microsoft.Extensions.Localization;

namespace LimakAz.Persistence.Localizers;

public class UserPanelLocalizer
{
    private readonly IStringLocalizer _stringLocalizer;

    public UserPanelLocalizer(IStringLocalizerFactory stringLocalizer)
    {
        _stringLocalizer = stringLocalizer.Create("UserPanel", "LimakAz.Presentation");
    }

    public string GetValue(string key)
    {
        return _stringLocalizer.GetString(key);
    }
}

