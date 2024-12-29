namespace LimakAz.Domain.Entities;

public class Shop : BaseEntity
{
    public string ImagePath { get; set; } = null!;
    public string Link { get; set; } = null!;
    public int CountryId { get; set; }
    public Country? Country { get; set; }
    public List<ShopCategory> ShopCategories { get; set; } = [];    
}

