namespace LimakAz.Application.AutoMappers;

internal class AppUserAutoMapper : Profile
{
    public AppUserAutoMapper()
    {
        CreateMap<AppUser, RegisterDto>().ReverseMap();
        CreateMap<AppUser,UserSettingDto>().ReverseMap();
    }
}
