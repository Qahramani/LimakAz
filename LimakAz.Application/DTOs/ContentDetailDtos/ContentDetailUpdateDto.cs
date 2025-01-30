namespace LimakAz.Application.DTOs;

public class ContentDetailUpdateDto : IDto
{
    public int Id { get; set; }
    public string? Key { get; set; }
    public string? Value { get; set; }
    public int LanguageId { get; set; }
}