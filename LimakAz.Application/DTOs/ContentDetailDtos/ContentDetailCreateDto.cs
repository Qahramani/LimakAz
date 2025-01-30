namespace LimakAz.Application.DTOs;

public class ContentDetailCreateDto : IDto
{
    public string? Key { get; set; }
    public string? Value { get; set; }
    public int LanguageId { get; set; }
}
