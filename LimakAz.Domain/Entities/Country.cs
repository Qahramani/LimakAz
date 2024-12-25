namespace LimakAz.Domain.Entities;

public class Country : BaseEntity
{
   
 //   public string Currency { get; set; } = null!;
    public string ImagePath { get; set; } = null!;
    public ICollection<CountryDetail> CountryDetails { get; set; } = [];
    public ICollection<Shop> Shops { get; set; } = [];
}
