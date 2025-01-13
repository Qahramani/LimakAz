using System.Net;

namespace LimakAz.Application.Exceptions    ;

public interface IBaseException
{
    public HttpStatusCode StatusCode { get; set; }
}
