namespace LimakAz.Application.AutoMappers;

internal class NotificationDetailAutoMapper : Profile
{
    public NotificationDetailAutoMapper()
    {
        CreateMap<NotificationDetail, NotificationDetailGetDto>().ReverseMap();
        CreateMap<NotificationDetail, NotificationDetailUpdateDto>().ReverseMap();
        CreateMap<NotificationDetail, NotificationDetailCreateDto>().ReverseMap();
    }
}