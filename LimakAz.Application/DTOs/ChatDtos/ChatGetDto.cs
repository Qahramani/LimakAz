namespace LimakAz.Application.DTOs;

public class ConnectionDto
{
    public string UserId { get; set; } = null!;
    public List<string> ConnectionIds { get; set; } = [];
}

public class ChatGetDto : IDto
{
    public int Id { get; set; }
    public string UserId { get; set; } = null!;
    public AppUser? User { get; set; }
    public string? ModeratorId { get; set; }
    public AppUser? Moderator { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<MessageGetDto> Messages { get; set; } = [];
}
