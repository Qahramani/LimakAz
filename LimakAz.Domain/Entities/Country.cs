namespace LimakAz.Domain.Entities;

public class Country : BaseAuditableEntity
{
    public string ImagePath { get; set; } = null!;
    public ICollection<CountryDetail> CountryDetails { get; set; } = [];
    public ICollection<Shop> Shops { get; set; } = [];
    public ICollection<Tariff> Tariffs{ get; set; } = [];
}
