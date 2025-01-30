namespace LimakAz.Application.DTOs;

public class NotificationGetDto : IDto
{
    public int Id { get; set; }
    public DateTime? SentTime { get; set; }
    public List<NotificationDetailGetDto> NotificationDetails { get; set; } = [];
}
