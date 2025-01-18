namespace LimakAz.Application.AutoMappers;

internal class NotificationAutoMapper : Profile
{
    public NotificationAutoMapper()
    {
        CreateMap<Notification, NotificationGetDto>().ReverseMap();
        CreateMap<Notification, NotificationUpdateDto>().ReverseMap();
        CreateMap<Notification, NotificationCreateDto>().ReverseMap();
    }
}
