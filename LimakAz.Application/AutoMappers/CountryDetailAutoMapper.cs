namespace LimakAz.Application.AutoMappers;

internal class CountryDetailAutoMapper : Profile
{
    public CountryDetailAutoMapper()
    {
        CreateMap<CountryDetail, CountryDetailGetDto>().ReverseMap();
        CreateMap<CountryDetail, CountryDetailCreateDto>().ReverseMap();
        CreateMap<CountryDetail, CountryDetailUpdateDto>().ReverseMap();

    }
}
