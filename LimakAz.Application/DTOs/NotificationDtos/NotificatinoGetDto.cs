namespace LimakAz.Application.DTOs;

public class NotificationGetDto : IDto
{
    public int Id { get; set; }
    public DateTime? SentTime { get; set; }
    public List<NotificationDetailGetDto> NotificationDetails { get; set; } = [];
}

public class NotificationCreateDto : IDto
{
    public DateTime? SentTime { get; set; }
    public List<NotificationDetailCreateDto> NotificationDetails { get; set; } = [];
}

public class NotificationUpdateDto : IDto
{
    public int Id { get; set; }
    public DateTime? SentTime { get; set; }
    public List<NotificationDetailUpdateDto> NotificationDetails { get; set; } = [];
}
