namespace LimakAz.Application.AutoMappers;

internal class StatusDetailAutoMapper : Profile
{
    public StatusDetailAutoMapper()
    {
        CreateMap<StatusDetail, StatusDetailGetDto>().ReverseMap();
        CreateMap<StatusDetail, StatusDetailUpdateDto>().ReverseMap();
        CreateMap<StatusDetail, StatusDetailCreateDto>().ReverseMap();
    }
}

