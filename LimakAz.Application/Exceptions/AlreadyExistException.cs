using System.Net;

namespace LimakAz.Application.Exceptions;

public class AlreadyExistException : Exception, IBaseException
{
    public AlreadyExistException(string message = "Movcuddur") : base(message)
    {

    }
    public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.Conflict;
}