namespace LimakAz.Application.DTOs;

public class NewsDetailCreateDto : IDto
{
    public string? Title { get; set; } 
    public string? Description { get; set; } 
    public int LanguageId { get; set; }
}
