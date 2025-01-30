using System.Net;

namespace LimakAz.Application.Exceptions;

public class InvalidRateExchangeException : Exception, IBaseException
{
    public InvalidRateExchangeException(string message = "Etibarsız məzənnə") : base(message)
    {

    }
    public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.BadRequest;
}
