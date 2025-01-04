namespace LimakAz.Application.AutoMappers;

internal class GenderDetailAutoMapper : Profile
{
    public GenderDetailAutoMapper()
    {
        CreateMap<GenderDetail, GenderDetailGetDto>().ReverseMap();
    }
}