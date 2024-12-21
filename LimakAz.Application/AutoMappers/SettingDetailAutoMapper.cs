namespace LimakAz.Application.AutoMappers;

internal class SettingDetailAutoMapper : Profile
{
    public SettingDetailAutoMapper()
    {
        CreateMap<SettingDetail, SettingDetailUpdateDto>().ReverseMap();
    }
}
