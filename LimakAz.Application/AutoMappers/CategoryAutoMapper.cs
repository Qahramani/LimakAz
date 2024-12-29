namespace LimakAz.Application.AutoMappers;

internal class CategoryAutoMapper : Profile
{
    public CategoryAutoMapper()
    {
        CreateMap<Category, CategoryGetDto>().ReverseMap();
        CreateMap<Category, CategoryCreateDto>().ReverseMap();
        CreateMap<Category, CategoryUpdateDto>().ReverseMap();
    }
}
