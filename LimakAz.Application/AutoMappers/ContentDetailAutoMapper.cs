namespace LimakAz.Application.AutoMappers;

internal class ContentDetailAutoMapper : Profile
{
    public ContentDetailAutoMapper()
    {
        CreateMap<ContentDetail, ContentDetailGetDto>().ReverseMap();
        CreateMap<ContentDetail, ContentDetailCreateDto>().ReverseMap();
        CreateMap<ContentDetail, ContentDetailUpdateDto>().ReverseMap();

    }
}
