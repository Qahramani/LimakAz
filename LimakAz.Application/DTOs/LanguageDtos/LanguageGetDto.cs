
namespace LimakAz.Application.DTOs.LanguageDtos;

public class LanguageGetDto : IDto
{
    public int Id { get; set; }
    public string? IsoCode { get; set; }
    public string? ImagePath { get; set; }
}
