namespace LimakAz.Domain.Entities;

public class AddressLine : BaseEntity
{
    public string Key { get; set; } = null!;
    public string Value { get; set; } = null!;
    public int CountryId { get; set; }
    public Country? Country { get; set; }
}

