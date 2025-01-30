namespace LimakAz.Application.DTOs;

public class NotificationUpdateDto : IDto
{
    public int Id { get; set; }
    public DateTime? SentTime { get; set; }
    public List<NotificationDetailUpdateDto> NotificationDetails { get; set; } = [];
}
