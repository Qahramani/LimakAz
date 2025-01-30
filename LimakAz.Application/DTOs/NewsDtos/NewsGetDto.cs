namespace LimakAz.Application.DTOs;

public class NewsGetDto : IDto
{
    public int Id { get; set; }
    public string? ImagePath { get; set; }
    public DateTime UpdatedAt { get; set; } 
    public List<NewsDetailGetDto> NewsDetails { get; set; } = [];
}
