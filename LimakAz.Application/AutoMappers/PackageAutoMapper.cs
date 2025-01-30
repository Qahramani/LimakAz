namespace LimakAz.Application.AutoMappers;

public class PackageAutoMapper : Profile
{
    public PackageAutoMapper()
    {

        CreateMap<Package, PackageGetDto>().ReverseMap();
        //CreateMap<Package, NewsCreateDto>().ReverseMap();
        //CreateMap<Package, NewsUpdateDto>().ReverseMap();
    }
}
