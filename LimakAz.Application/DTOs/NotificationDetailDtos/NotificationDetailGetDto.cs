namespace LimakAz.Application.DTOs;

public class NotificationDetailGetDto : IDto
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public int LanguageId { get; set; }
    public int NotificationId { get; set; }
    public Notification? Notification { get; set; }
}

public class NotificationDetailCreateDto : IDto
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public int LanguageId { get; set; }
}

public class NotificationDetailUpdateDto : IDto
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public int LanguageId { get; set; }
}