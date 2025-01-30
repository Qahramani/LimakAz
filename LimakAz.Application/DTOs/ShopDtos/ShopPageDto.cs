namespace LimakAz.Application.DTOs;

public class ShopPageDto
{
    public List<ShopGetDto>? Shops { get; set; } = [];
    public List<CategoryGetDto>? Categories { get; set; } = [];
    public List<CountryGetDto>? Countries { get; set; } = [];
    public int PageCount { get; set; }
    public int CurrentPage { get; set; }
}