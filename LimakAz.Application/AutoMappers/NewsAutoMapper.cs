namespace LimakAz.Application.AutoMappers;

public class NewsAutoMapper : Profile
{
    public NewsAutoMapper()
    {
       // CreateMap<News,NewsGetDto>().ForMember(dest => dest.Title, src => src.MapFrom(x => x.NewsDetails.FirstOrDefault() != null ? x.NewsDetails.FirstOrDefault()!.Title : string.Empty)).ReverseMap();

        CreateMap<News,NewsGetDto>().ReverseMap();
        CreateMap<News,NewsCreateDto>().ReverseMap();
        CreateMap<News,NewsUpdateDto>().ReverseMap();
    }
}

public class NewsDetailAutoMapper : Profile
{
    public NewsDetailAutoMapper()
    {
        CreateMap<NewsDetail, NewsDetailGetDto>().ReverseMap();
        CreateMap<NewsDetail, NewsDetailCreateDto>().ReverseMap();
        CreateMap<NewsDetail, NewsDetailUpdateDto>().ReverseMap();
    }
}
