namespace LimakAz.Application.DTOs;

public class ShopGetDto : IDto
{
    public int Id { get; set; }
    public string? ImagePath { get; set; } 
    public string? Link { get; set; } 
    public int CountryId { get; set; }
    public string? CountryName { get; set; }
}
