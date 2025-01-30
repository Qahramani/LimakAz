namespace LimakAz.Application.DTOs;

public class NotificationDetailUpdateDto : IDto
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public int LanguageId { get; set; }
}