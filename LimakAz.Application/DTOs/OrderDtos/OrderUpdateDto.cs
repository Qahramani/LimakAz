namespace LimakAz.Application.DTOs;

public class OrderUpdateDto : IDto
{
    public int Id { get; set; }
    public string? Link { get; set; }
    public decimal ItemPrice { get; set; }
    public bool IsLocalCargoFree { get; set; }
    public decimal LocalCargoPrice { get; set; } = 0;
    public decimal TotalCargoPrice { get; set; }
    public int Count { get; set; }
    public string? Color { get; set; }
    public string? Size { get; set; }
    public string? Notes { get; set; }
    public int CountryId { get; set; }
    public List<CountryGetDto> Countries { get; set; } = [];
    public int LocalPointId { get; set; }
    public List<LocalPointGetDto> LocalPoints { get; set; } = [];
}
