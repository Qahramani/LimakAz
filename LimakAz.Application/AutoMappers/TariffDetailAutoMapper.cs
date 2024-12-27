namespace LimakAz.Application.AutoMappers;

internal class TariffDetailAutoMapper : Profile
{
    public TariffDetailAutoMapper()
    {
        CreateMap<TariffDetail, TariffDetailGetDto>().ReverseMap();
        CreateMap<TariffDetail, TariffDetailCreateDto>().ReverseMap();
        CreateMap<TariffDetail, TariffDetailUpdateDto>().ReverseMap();

    }
}