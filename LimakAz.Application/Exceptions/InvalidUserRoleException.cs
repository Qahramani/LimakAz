using System.Net;

namespace LimakAz.Application.Exceptions;

public class InvalidUserRoleException : Exception, IBaseException
{
    public InvalidUserRoleException(string message = "") : base(message)
    {
        
    }
    public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.NotAcceptable;
}
