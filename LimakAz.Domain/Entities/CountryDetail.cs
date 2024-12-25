namespace LimakAz.Domain.Entities;

public class CountryDetail : BaseEntity
{
    public string Name { get; set; } = null!;
    public int CountryId { get; set; }
    public Country? Country { get; set; }
    public int LanguageId { get; set; }
    public Language? Language { get; set; }
}
