namespace LimakAz.Application.AutoMappers;

internal class CountryAutoMapper : Profile
{
    public CountryAutoMapper()
    {
        CreateMap<Country, CountryGetDto>().ReverseMap();
        CreateMap<Country, CountryCreateDto>().ReverseMap();
        CreateMap<Country, CountryUpdateDto>().ReverseMap();

    }
}
