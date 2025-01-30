namespace LimakAz.Application.DTOs;

public class ChatUpdateDto : IDto
{
    public int Id { get; set; }
    public string UserId { get; set; } = null!;
    public AppUser? User { get; set; }
    public string ModeratorId { get; set; } = null!;
    public AppUser? Moderator { get; set; }
    public bool IsActive { get; set; }
    public List<MessageGetDto> Messages { get; set; } = [];
}
