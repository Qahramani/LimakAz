namespace LimakAz.Presentation.Extentions;

public static class ExtentionMethods
{
    public static string GetReturnUrl(this HttpRequest httpRequest)
    {
        string? returnUrl = httpRequest.Headers["Referer"];

        if (returnUrl == null)
            return "/";

        return returnUrl;
    }
}
