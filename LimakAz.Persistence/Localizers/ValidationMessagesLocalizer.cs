using LimakAz.Application.Interfaces.Helpers;
using Microsoft.Extensions.Localization;

namespace LimakAz.Persistence.Localizers;

public class ValidationMessagesLocalizer : IValidationMessageProvider
{
    private readonly IStringLocalizer _stringLocalizer;

    public ValidationMessagesLocalizer(IStringLocalizerFactory stringLocalizer)
    {
        _stringLocalizer = stringLocalizer.Create("ValidationMessages", "LimakAz.Presentation");
    }

    public string GetValue(string key)
    {
        return _stringLocalizer.GetString(key);
    }
}
