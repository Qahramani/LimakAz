namespace LimakAz.Domain.Entities;

public class ContentDetail : BaseEntity
{
    public string Key { get; set; } = null!;
    public string Value { get; set; } = null!;
    public int ContentId { get; set; }
    public Content? Content{ get; set; }
    public int LanguageId { get; set; }
    public Language? Language { get; set; }
}