using System.Net;

namespace LimakAz.Application.Exceptions;

public class InvalidUserRoleException : Exception, IBaseException
{
    public InvalidUserRoleException(string message = "İstifadəçi Rolu Yanlışdir") : base(message)
    {
        
    }
    public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.NotAcceptable;
}
