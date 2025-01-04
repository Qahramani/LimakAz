namespace LimakAz.Application.AutoMappers;

internal class GenderAutoMapper : Profile
{
    public GenderAutoMapper()
    {
        CreateMap<Gender, GenderGetDto>().ReverseMap();
    }
}
