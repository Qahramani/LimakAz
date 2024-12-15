namespace LimakAz.Application.DTOs;

public class SettingDetailUpdateDto : IDto
{
    public int LanguageId { get; set; }
    public string Value { get; set; } = null!;
}