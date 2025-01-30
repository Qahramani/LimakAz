namespace LimakAz.Application.AutoMappers;

public class NewsDetailAutoMapper : Profile
{
    public NewsDetailAutoMapper()
    {
        CreateMap<NewsDetail, NewsDetailGetDto>().ReverseMap();
        CreateMap<NewsDetail, NewsDetailCreateDto>().ReverseMap();
        CreateMap<NewsDetail, NewsDetailUpdateDto>().ReverseMap();
    }
}
