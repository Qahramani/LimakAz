namespace LimakAz.Application.DTOs;

public class NotificationCreateDto : IDto
{
    public DateTime? SentTime { get; set; }
    public List<NotificationDetailCreateDto> NotificationDetails { get; set; } = [];
}
