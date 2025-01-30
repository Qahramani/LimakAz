namespace LimakAz.Application.DTOs;

public class CategoryDetailCreateDto : IDto
{
    public string? Name { get; set; } 
    public int LanguageId { get; set; }
}
