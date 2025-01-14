using Microsoft.Extensions.Localization;

namespace LimakAz.Persistence.Localizers;

public class AccountLocalizer
{
    private readonly IStringLocalizer _stringLocalizer;

    public AccountLocalizer(IStringLocalizerFactory stringLocalizer)
    {
        _stringLocalizer = stringLocalizer.Create("Account", "LimakAz.Presentation");
    }

    public string GetValue(string key)
    {
        return _stringLocalizer.GetString(key);
    }
}
