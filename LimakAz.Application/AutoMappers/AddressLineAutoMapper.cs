namespace LimakAz.Application.AutoMappers;

internal class AddressLineAutoMapper : Profile
{
    public AddressLineAutoMapper()
    {
        CreateMap<AddressLine, AddressLineGetDto>().ReverseMap();
        CreateMap<AddressLine, AddressLineUpdateDto>().ReverseMap();
        CreateMap<AddressLine, AddressLineCreateDto>().ReverseMap();
    }
}
