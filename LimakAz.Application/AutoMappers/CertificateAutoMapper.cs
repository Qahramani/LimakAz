namespace LimakAz.Application.AutoMappers;

internal class CertificateAutoMapper : Profile
{
    public CertificateAutoMapper()
    {
        CreateMap<Certificate, CertificateGetDto>().ReverseMap();
        CreateMap<Certificate, CertificateCreateDto>().ReverseMap();
        CreateMap<Certificate, CertificateUpdateDto>().ReverseMap();
    }
}
