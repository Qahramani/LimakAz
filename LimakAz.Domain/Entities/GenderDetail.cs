namespace LimakAz.Domain.Entities;

public class GenderDetail : BaseEntity
{
    public string Name { get; set; } = null!;
    public int GenderId { get; set; }
    public Gender? Gender { get; set; }
    public int LanguageId { get; set; }
    public Language? Language { get; set; }
}
