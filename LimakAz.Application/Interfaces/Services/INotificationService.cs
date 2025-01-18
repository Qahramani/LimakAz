using LimakAz.Application.Interfaces.Services.Generic;

namespace LimakAz.Application.Interfaces.Services;

public interface INotificationService : IGetService<NotificationGetDto>, IModifyService<NotificationCreateDto, NotificationUpdateDto>
{
}
