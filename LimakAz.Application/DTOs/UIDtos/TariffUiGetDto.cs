namespace LimakAz.Application.DTOs;

public class TariffUiGetDto
{
    public string? CountryName { get; set; }
    public string? ImagePath { get; set; }
    public List<FormattedTariffGetDto> Tariffs { get; set; } = [];
    public List<string> LocalPoints{ get; set; } = [];

}

public class FormattedTariffGetDto
{
    public string? Value { get; set; }
    public string? PriceInAZN { get; set; }
    public string? PriceInUSD { get; set; }
}