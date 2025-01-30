using System.Net;

namespace LimakAz.Application.Exceptions;

public class InvalidInputException : Exception, IBaseException
{
    public InvalidInputException(string message = "Daxil etdiyiniz deyer yanlisdir") : base(message)
    {

    }
    public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.Conflict;
}