namespace LimakAz.Application.DTOs;

public class NewsDetailsUiDto
{
    public NewsGetDto? SelectedNews { get; set; }
    public List<NewsGetDto> RecommendedNews { get; set; } = [];
}