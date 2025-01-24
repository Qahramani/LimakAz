using System.Net;

namespace LimakAz.Application.Exceptions;

public class EmptyBasketException : Exception, IBaseException
{
    public EmptyBasketException(string message = "Sebetiniz bosdur") : base(message)
    {

    }
    public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.NotFound;
}
