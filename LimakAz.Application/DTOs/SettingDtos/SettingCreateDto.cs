namespace LimakAz.Application.DTOs;

public class SettingCreateDto : IDto
{
    public string? Key { get; set; }
    public List<SettingDetailUpdateDto> SettingDetails { get; set; } = [];
}