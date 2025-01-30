namespace LimakAz.Application.DTOs;

public class OrderItemCreateDto : IDto
{
    public string? Link { get; set; }
    public decimal ItemPrice { get; set; }
    public decimal LocalCargoPrice { get; set; } = 0;
    public decimal OrderItemTotalPrice { get; set; }
    public int Count { get; set; } = 1;
    public string? Color { get; set; }
    public string? Size { get; set; }
    public string? Notes { get; set; }
    public int CountryId { get; set; } = 1;
    public List<CountryGetDto> Countries { get; set; } = [];
}
