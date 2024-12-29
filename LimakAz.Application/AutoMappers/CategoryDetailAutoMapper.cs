namespace LimakAz.Application.AutoMappers;

internal class CategoryDetailAutoMapper : Profile
{
    public CategoryDetailAutoMapper()
    {
        CreateMap<CategoryDetail, CategoryDetailGetDto>().ReverseMap();
        CreateMap<CategoryDetail, CategoryDetailCreateDto>().ReverseMap();
        CreateMap<CategoryDetail, CategoryDetailUpdateDto>().ReverseMap();
    }
}