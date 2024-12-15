namespace LimakAz.Domain.Entities;

public class LocationDetail : BaseEntity
{
    public string Name { get; set; } = null!;
    public int LocationId { get; set; }
    public Location? Location { get; set; }
    public int LanguageId { get; set; }
    public Language? Language { get; set; }
}