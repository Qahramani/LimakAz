namespace LimakAz.Application.DTOs;

public class MessageUpdateDto : IDto
{
    public int Id { get; set; }
    public string? Text { get; set; }
    public int ChatId { get; set; }
}
