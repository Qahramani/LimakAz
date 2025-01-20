namespace LimakAz.Application.AutoMappers;

internal class StatusAutoMapper : Profile
{
    public StatusAutoMapper()
    {
        CreateMap<Status, StatusGetDto>().ReverseMap();
        CreateMap<Status, StatusUpdateDto>().ReverseMap();
        CreateMap<Status, StatusCreateDto>().ReverseMap();
    }
}

