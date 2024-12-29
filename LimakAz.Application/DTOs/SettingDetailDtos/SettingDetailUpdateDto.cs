namespace LimakAz.Application.DTOs;

public class SettingDetailUpdateDto
{
    public int Id { get; set; }
    public string? Value { get; set; }
    public int LanguageId { get; set; }
    public int SettingId { get; set; }
}