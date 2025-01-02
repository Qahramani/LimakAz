namespace LimakAz.Application.DTOs;

public class TariffUiGetDto
{
    public string? CountryName { get; set; }
    public List<LocalPointGetDto> LocalPoints { get; set; } = [];
    public List<string> Lines { get; set; } = [];
}
