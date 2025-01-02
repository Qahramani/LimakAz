namespace LimakAz.Application.AutoMappers;

internal class LocalPointDetailAutoMapper : Profile
{
    public LocalPointDetailAutoMapper()
    {
        CreateMap<LocalPointDetail, LocalPointDetailGetDto>().ReverseMap();
        CreateMap<LocalPointDetail, LocalPointDetailCreateDto>().ReverseMap();
        CreateMap<LocalPointDetail, LocalPointDetailUpdateDto>().ReverseMap();
    }
}
