using System.Net;

namespace LimakAz.Persistence.Exceptions;

public interface IBaseException
{
    public HttpStatusCode StatusCode { get; set; }
}
