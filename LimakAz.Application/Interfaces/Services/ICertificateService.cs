using LimakAz.Application.Interfaces.Services.Generic;


namespace LimakAz.Application.Interfaces.Services;

public interface ICertificateService : IGetService<CertificateGetDto>, IModifyService<CertificateCreateDto, CertificateUpdateDto>
{
}