namespace LimakAz.Application.AutoMappers;

internal class LocalPointAutoMapper : Profile
{
    public LocalPointAutoMapper()
    {
        CreateMap<LocalPoint, LocalPointGetDto>().ReverseMap();
        CreateMap<LocalPoint, LocalPointCreateDto>().ReverseMap();
        CreateMap<LocalPoint, LocalPointUpdateDto>().ReverseMap();
    }
}
