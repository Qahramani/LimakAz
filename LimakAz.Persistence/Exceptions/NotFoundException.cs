using System.Net;

namespace LimakAz.Persistence.Exceptions;

public class NotFoundException : Exception, IBaseException
{
    public NotFoundException(string message = "Not Found") : base(message)  
    {
        
    }
    public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.NotFound;
}

