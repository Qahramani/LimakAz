using LimakAz.Application.Exceptions;

namespace LimakAz.Presentation.Extentions;

public class GlobalExceptionHandler
{
    private readonly RequestDelegate _next;

    public GlobalExceptionHandler(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next.Invoke(context);
        }
        catch (Exception exception)
        {
            int StatusCode = 500;
            string message = "Xəta baş verdi";
            if (exception is IBaseException e)
            {
                message = exception.Message;
                StatusCode = (int)e.StatusCode;
            }

            string errorPath = $"/Home/Error?message={message}&statusCode={StatusCode}";

            context.Response.Redirect(errorPath);
               
        }
    }
}
