namespace LimakAz.Application.DTOs;

public class NewsDetailGetDto : IDto
{
    public string? Title { get; set; } 
    public string? Description { get; set; } 
    public int NewsId { get; set; }
    public int LanguageId { get; set; }
}

public class NewsDetailCreateDto : IDto
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int LanguageId { get; set; }
}

public class NewsDetailUpdateDto : IDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int LanguageId { get; set; }
}

