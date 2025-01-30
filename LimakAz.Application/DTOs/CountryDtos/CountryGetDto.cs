namespace LimakAz.Application.DTOs;

public class CountryGetDto : IDto
{
    public int Id { get; set; }
    public string? ImagePath { get; set; }
    public List<CountryDetailGetDto> CountryDetails { get; set; } = [];
    public List<TariffGetDto> Tariffs { get; set; } = [];
}

