namespace LimakAz.Application.DTOs;

public class SettingUpdateDto 
{
    public int Id { get; set; }
    public string? Key { get; set; }
    public List<SettingDetailUpdateDto> SettingDetails { get; set; } = [];
}