namespace LimakAz.Application.AutoMappers;

public class NewsAutoMapper : Profile
{
    public NewsAutoMapper()
    {

        CreateMap<News,NewsGetDto>().ReverseMap();
        CreateMap<News,NewsCreateDto>().ReverseMap();
        CreateMap<News,NewsUpdateDto>().ReverseMap();
    }
}
