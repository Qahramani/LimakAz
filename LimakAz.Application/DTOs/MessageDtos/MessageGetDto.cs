namespace LimakAz.Application.DTOs;

public class MessageGetDto : IDto
{
    public  int Id { get; set; }
    public string? Text { get; set; }
    public string UserId { get; set; } = null!;
    public AppUser? User { get; set; }
    public int ChatId { get; set; }
    public ChatGetDto? Chat { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class MessageDisplayDto
{
    public string UserId { get; set; } = null!;
    public string ChatId { get; set; } = null!;

    public string? Fullname { get; set; }
    public string? Text { get; set; }
    public DateTime  SendAt{ get; set; }
}

public class MessageCreateDto : IDto
{
    public string? Text { get; set; }
    public int ChatId { get; set; }
}

public class MessageUpdateDto : IDto
{
    public int Id { get; set; }
    public string? Text { get; set; }
    public int ChatId { get; set; }
}
