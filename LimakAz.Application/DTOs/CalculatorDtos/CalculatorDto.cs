using Microsoft.AspNetCore.Mvc.Rendering;

namespace LimakAz.Application.DTOs;

public class CalculatorDto
{
    public int CountryId { get; set; }
    public List<CountryGetDto> Countries { get; set; } = [];
    public int LocalPointId { get; set; }
    public List<LocalPointGetDto> LocalPoints { get; set; } = [];
    public int Count { get; set; }
    public decimal Weight { get; set; }
    public decimal Width { get; set; }
    public decimal Lenght { get; set; }
    public decimal Height { get; set; }
    public MatterType MatterType { get; set; }
    public decimal TotalPriceInAzn { get; set; }
    public decimal TotalPriceInUsd { get; set; }
}
