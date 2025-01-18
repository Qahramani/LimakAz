namespace LimakAz.Application.DTOs;

public class MessageGetDto : IDto
{
    public  int Id { get; set; }
    public string? Text { get; set; }
    public int UserId { get; set; }
    public AppUser? User { get; set; }
    public int ChatId { get; set; }
    public ChatGetDto? Chat { get; set; }
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
