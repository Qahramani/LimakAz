namespace LimakAz.Application.DTOs;

public class ChatGetDto : IDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public AppUser? User { get; set; }
    public int ModeratorId { get; set; }
    public AppUser? Moderator { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<MessageGetDto> Messages { get; set; } = [];
}

public class ChatCreateDto : IDto
{
    public int UserId { get; set; }
    public int ModeratorId { get; set; }
}


public class ChatUpdateDto : IDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public AppUser? User { get; set; }
    public int ModeratorId { get; set; }
    public AppUser? Moderator { get; set; }
    public bool IsActive { get; set; }
    public List<MessageGetDto> Messages { get; set; } = [];
}
