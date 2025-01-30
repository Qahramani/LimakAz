namespace LimakAz.Application.DTOs;

public class NewsDetailGetDto : IDto
{
    public string? Title { get; set; } 
    public string? Description { get; set; } 
    public int NewsId { get; set; }
    public int LanguageId { get; set; }
}
