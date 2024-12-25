namespace LimakAz.Application.AutoMappers;

internal class CertificateAutoMapper : Profile
{
    public CertificateAutoMapper()
    {
        CreateMap<Certificate, CertificateGetDto>();
        CreateMap<Certificate, CertificateCreateDto>();
        CreateMap<Certificate, CertificateUpdateDto>();
    }
}