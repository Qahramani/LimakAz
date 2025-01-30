namespace LimakAz.Application.DTOs;

public class CountryDetailCreateDto : IDto
{
    public string? Name { get; set; } 
    public int LanguageId { get; set; }
}
