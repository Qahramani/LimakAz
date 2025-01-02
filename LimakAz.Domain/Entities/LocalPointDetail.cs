namespace LimakAz.Domain.Entities;

public class LocalPointDetail : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string WorkingHourse { get; set; } = null!;
    public int LocalPointId { get; set; }
    public LocalPoint? LocalPoint { get; set; }
    public int LanguageId { get; set; }
    public Language? Language { get; set; }
}
