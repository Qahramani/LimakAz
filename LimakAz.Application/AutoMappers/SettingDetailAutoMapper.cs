namespace LimakAz.Application.AutoMappers;

internal class SettingDetailAutoMapper : Profile
{
    public SettingDetailAutoMapper()
    {
        CreateMap<SettingDetail, SettingDetailCreateDto>().ReverseMap();
        CreateMap<SettingDetail, SettingDetailUpdateDto>().ReverseMap();
    }
}
