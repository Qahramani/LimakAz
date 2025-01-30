namespace LimakAz.Application.DTOs;

public class ChatCreateDto : IDto
{
    public string UserId { get; set; } = null!;
    public int ModeratorId { get; set; }
}
