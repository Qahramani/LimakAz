namespace LimakAz.Application.DTOs;

public class CountryDetailUpdateDto : IDto
{
    public int Id { get; set; }
    public string? Name { get; set; } 
    public int LanguageId { get; set; }
}