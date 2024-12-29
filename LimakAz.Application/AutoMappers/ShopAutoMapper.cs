using System.Data;

namespace LimakAz.Application.AutoMappers;

internal class ShopAutoMapper : Profile
{
    public ShopAutoMapper()
    {
        CreateMap<Shop, ShopGetDto>().ForMember(src => src.CountryName, x => x.MapFrom(x => x.Country.CountryDetails.FirstOrDefault().Name != null ? x.Country.CountryDetails.FirstOrDefault()!.Name : string.Empty));
        CreateMap<Shop, ShopCreateDto>().ReverseMap();
        CreateMap<Shop, ShopUpdateDto>().ReverseMap();
    }
}
