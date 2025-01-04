using LimakAz.Application.DTOs;
using LimakAz.Domain.Entities;

namespace LimakAz.Application.AutoMappers;

internal class TariffAutoMapper : Profile
{
    public TariffAutoMapper()
    {
        CreateMap<Tariff, TariffGetDto>().ReverseMap();
        CreateMap<Tariff, TariffCreateDto>().ReverseMap();
        CreateMap<Tariff, TariffUpdateDto>().ReverseMap();

    }
}
