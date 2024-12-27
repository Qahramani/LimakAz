namespace LimakAz.Domain.Entities;

public class TariffDetail : BaseEntity
{
    public string? Note { get; set; }
    public int TariffId { get; set; }
    public Tariff? Tariff { get; set; }
    public int LanguageId { get; set; }
    public Language? Language { get; set; }
}