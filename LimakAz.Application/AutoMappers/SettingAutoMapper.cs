namespace LimakAz.Application.AutoMappers;

internal class SettingAutoMapper : Profile
{
    public SettingAutoMapper()
    {
        CreateMap<Setting,SettingGetDto>()
            .ForMember(x => x.Value, x => x.MapFrom( x=> x.SettingDetails.FirstOrDefault() != null ? x.SettingDetails.FirstOrDefault()!.Value : string.Empty));
    }
}
