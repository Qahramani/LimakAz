namespace LimakAz.Application.AutoMappers;

internal class ContentAutoMapper : Profile
{
    public ContentAutoMapper()
    {
        CreateMap<Content, ContentGetDto>().ReverseMap();
        CreateMap<Content, ContentCreateDto>().ReverseMap();
        CreateMap<Content, ContentUpdateDto>().ReverseMap();

    }
}
