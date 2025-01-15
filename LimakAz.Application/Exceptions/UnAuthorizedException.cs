using System.Net;

namespace LimakAz.Application.Exceptions;

public class UnAuthorizedException : Exception, IBaseException
{
    public UnAuthorizedException(string message = "Unauthorized") : base(message)
    {

    }
    public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.Unauthorized;
}