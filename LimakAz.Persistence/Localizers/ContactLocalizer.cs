using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Localization;

namespace LimakAz.Persistence.Localizers;

public class ContactLocalizer
{
    private readonly IStringLocalizer _stringLocalizer;

    public ContactLocalizer(IStringLocalizerFactory stringLocalizer)
    {
        _stringLocalizer = stringLocalizer.Create("Contact", "LimakAz.Presentation");
    }

    public string GetValue(string key)
    {
        return _stringLocalizer.GetString(key);
    }
}
