namespace LimakAz.Application.DTOs;

public class MessageCreateDto : IDto
{
    public string? Text { get; set; }
    public int ChatId { get; set; }
}
